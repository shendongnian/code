    private void defineCellPositionsList()
    {
        for (int row = 0; row < rows; row++)
        {
            List<int> sublist = new List<int>();
            for (int col = 0; col < cols; col++)
            {
                sublist.Add(col);
                sublist.Add(row);
            }
            CellPositionsList.Add(sublist);
        }
    }
