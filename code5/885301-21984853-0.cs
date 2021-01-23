    for (int i = 2; i < DT.Columns.Count; i++)
    {
        foreach (DataRow DR in DT.Rows)
        {
            ColumnTotal = ColumnTotal + int.Parse(DR[i].ToString());
        }
    
        DataRow newRow = DT.NewRow();
        newRow[i] = ColumnTotal;
        DT.Rows.Add(newRow );
    
        ColumnTotal = 0;
    }
