byte[,] field =
{{1, 2, 3},
{4, 5, 6},
{7, 8, 9}};

for (int i = 0; i < 3; i++) // drawing the field
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write($" {field[i, j]} ");
        
        if (j != 2)
            Console.Write("|");
    }
    if (i != 2)
        Console.WriteLine("\n-----------");
}

bool isGameActive = true;

while (isGameActive)
{
    bool firstWin = false;
    bool secondWin = false;
    bool isDraw = true;

    for (int k = 1; k <= 2; k++) // k = 1 - player 1 ("X"); k = 2 - player 2 ("O")
    {
        bool isInputActive = true;

        while (isInputActive) // input
        {
            Console.Write($"\n\nPlayer's {k} move. Enter the number of cell: ");

            byte cellNumber;
            bool isParsed = byte.TryParse(Console.ReadLine(), out cellNumber);  // input verification
            if (isParsed && cellNumber >= 1 && cellNumber <= 9)
            {
                bool isFree = false; // checking if the cell is free

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (field[i, j] == cellNumber)
                        { 
                            if (k == 1)
                                field[i, j] = 11; // 11 = "X"
                            else
                                field[i, j] = 10; // 10 = "O"
                            isFree = true;
                        }
                    }
                }
                if (isFree)
                    break;
                else
                    Console.WriteLine("The cell is aready full. Try again.");
            }
            else
                Console.WriteLine("Invalid input. Try again.");
        }

        Console.Clear();

        for (int i = 0; i < 3; i++) // redrawing the field
        {
            for (int j = 0; j < 3; j++)
            {
                if (field[i, j] == 11)
                    Console.Write($" X ");
                else if (field[i, j] == 10)
                    Console.Write($" O ");
                else
                    Console.Write($" {field[i, j]} ");

                if (j != 2)
                    Console.Write("|");
            }
            if (i != 2)
                Console.WriteLine("\n-----------");
        }

        for (int i = 0; i < 3; i++) // win checking
        {
            if (field[i, 0] == 11 && field[i, 1] == 11 && field[i, 2] == 11)
                firstWin = true;
            else if (field[0, i] == 11 && field[1, i] == 11 && field[2, i] == 11)
                firstWin = true;
            else if (field[i, 0] == 10 && field[i, 1] == 10 && field[i, 2] == 10)
                secondWin = true;
            else if (field[0, i] == 10 && field[1, i] == 10 && field[2, i] == 10)
                secondWin = true;           
        }
        if (field[0, 0] == 11 && field[1, 1] == 11 && field[2, 2] == 11)
            firstWin = true;
        else if (field[0, 2] == 11 && field[1, 1] == 11 && field[2, 0] == 11)
            firstWin = true;
        else if (field[0, 0] == 10 && field[1, 1] == 10 && field[2, 2] == 10)
            secondWin = true;
        else if (field[0, 2] == 10 && field[1, 1] == 10 && field[2, 0] == 10)
            secondWin = true;

        if (firstWin)
        {
            Console.WriteLine("\n\nPlayer 1 has won!!!");
            break;
        }
        if (secondWin)
        {
            Console.WriteLine("\n\nPlayer 2 has won!!!");
            break;
        }
        foreach (byte cell in field) // draw checking
        {
            if (cell < 10)
                isDraw = false;
        }
        if (isDraw)
        {
            Console.WriteLine("\n\nDraw!!!");
            break;
        }
    }
    if (firstWin || secondWin || isDraw)
        break;
}

