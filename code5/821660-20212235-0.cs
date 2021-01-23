    dt.Columns.Add("c1", "First column");
    dt.Columns.Add("c2", "Second column");
    for (int Rnum = 1; Rnum <= 9; Rnum++)
    {	
        dt.Rows.Add(
                (ShtRange.Cells[Rnum, 1] as Excel.Range).Value2.ToString(), 
                (ShtRange.Cells[Rnum, 2] as Excel.Range).Value2.ToString());
    }
