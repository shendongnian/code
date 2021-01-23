    private void defineCellPositionsList()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                CellPositionsList.Add(new List<int> { col, row });
            }
        }
    }
