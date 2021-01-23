    DataTable1.Columns.Add("C1", typeof(Double));
    DataTable1.Columns.Add("C2", typeof(Double));
    DataTable1.Columns.Add("C3", typeof(Double));
    DataTable1.Columns.Add("Total", typeof(Double));
    DataTable1.Columns["Total"].Expression = "C1+C2+C3";
