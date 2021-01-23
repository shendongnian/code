    dataTable.Columns.Add(new DataColumn("SortOrder", System.Type.GetType("System.Int32")));
    foreach (DataRow row in dataTable.Rows)
    {
        var Line = Convert.ToInt32(row["Line"]);
        row["SortOrder"] = (Line * (int)Math.Ceiling((double)Line / 3)).ToString();
    }
    dataTable.DefaultView.Sort = "SortOrder Asc";
    dataTable = dataTable.DefaultView.ToTable();
