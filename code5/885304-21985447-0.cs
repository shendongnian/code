    var row = DT.NewRow();
    for (int i = 2; i < DT.Columns.Count; i++)
    {
        ColumnTotal = 0;
        foreach (DataRow DR in DT.Rows)
        {
            ColumnTotal = ColumnTotal + int.Parse(DR[i].ToString());
        }
        row[i] = ColumnTotal;
    }
    DT.Rows.Add(row);
