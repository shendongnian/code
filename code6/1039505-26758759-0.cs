    static void Main(string[] args)
    {
        Console.WriteLine("Enter values for Cell ID, Sample, Write/TX, Depass, Discharge Date and Discharge load.");
        String[,] CellDetailArray = new String[16, 6];
        for (int i = 0; i < CellDetailArray.GetLength(0); i++)
        {
            Console.WriteLine(string.Format("Data for row no. {0}:", i + 1));
            for (int j = 0; j < CellDetailArray.GetLength(1); j++)
            {
                Console.Write(string.Format("\tValue for column no. {0}: ", j + 1));
                CellDetailArray[i, j] = Console.ReadLine();
            }
        }
        Console.WriteLine("Data entry finished.\n\nArray contents:");
        for (int i = 0; i < CellDetailArray.GetLength(0); i++)
        {
            Console.Write(string.Format("\nRow no. {0}: ", i + 1));
            for (int j = 0; j < CellDetailArray.GetLength(1); j++)
            {
                Console.Write(string.Format("\"{0}\"", CellDetailArray[i, j]));
                if (j < CellDetailArray.GetLength(1) - 1)
                    Console.Write(", ");
            }
        }
    }
