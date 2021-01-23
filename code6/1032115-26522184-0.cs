    private UniformGrid fillLabels(int[,] board)
    {
        int numRow = board.GetLength(0);
        int numCol = board.GetLength(1);
        UniformGrid g = new UniformGrid() { Rows = numRow, Columns = numCol };
        for (int i = 0; i < numRow; i++)
        {
            for (int j = 0; j < numCol; j++)
            {
                Label l = new Label();
                l.Content = (board[i, j] == 0) ? "O" : "X";
                Grid.SetRow(l, i);
                Grid.SetColumn(l, j);
                g.Children.Add(l);
            }
        }
        return g;
    }
