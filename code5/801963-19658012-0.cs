    public string selectCell(int Column, int Row)
    {
        if (CurrentTable.Rows.Count <= Row)   // zero based indices
            throw new ArgumentException("Invalid number of rows in selectCell", "Row");
        if (CurrentTable.Columns.Count <= Column)
            throw new ArgumentException("Invalid number of columns in selectCell", "Column");
        var row = CurrentTable.Rows[Row];
        if (row.IsNull(Column))
            return null;
        return row[Column].ToString();
    }
