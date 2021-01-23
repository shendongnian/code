    public void readFromFile()
    {
        StreamReader str = new StreamReader("SUDOKU.txt");
        for (int i = 0; i < 9; ++i)
        {
            string[] lineNumbers = str.ReadLine().Split(' ');
            for (int j = 0; j < 9; ++j)
            {
                puzzle[i, j] = Convert.ToInt32(lineNumbers[j]);
            }
        }
        str.Close();
    }
