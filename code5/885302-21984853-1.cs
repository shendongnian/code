    DataRow newRow = DT.NewRow();
    for (int i = 2; i < DT.Columns.Count; i++)
    {
        foreach (DataRow DR in DT.Rows)
        {
            ColumnTotal = ColumnTotal + int.Parse(DR[i].ToString());
        }
         
        newRow[i] = ColumnTotal;
    
        ColumnTotal = 0;
    }
    DT.Rows.Add(newRow);
