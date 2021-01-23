    private void ResizeColumns(DataGridView gridview, int column, int width, DataGridViewAutoSizeColumnMode mode)
    {
        for (int i = 0; i < gridview.ColumnCount; i++)
        {
            if (i.Equals(column))
            {
                gridview.Columns[i].AutoSizeMode = mode;
                gridview.Columns[i].Width = width;
            }
            else
            {
                gridview.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }
    }
