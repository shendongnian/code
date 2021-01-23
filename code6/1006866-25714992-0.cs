    for(int i = 0; i < foundRows.Length; i ++)
    {
        for(int c = 0; c < table.Columns.Count; c++)
            MessageBox.Show(foundRows[i][c].ToString());
    }
