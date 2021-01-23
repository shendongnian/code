    dataTable.Columns.Add(new DataColumn("SortOrder", System.Type.GetType("System.Int32")));
    var iCount = 0;
    var previousLine = 0;
    foreach (DataRow row in dataTable.Rows)
    {
        var Line = Convert.ToInt32(row["Line"]);
        if (previousLine != Line)
        {
            iCount = 0;
        }
        previousLine = Line;
        row["SortOrder"] = Line + iCount * 3;
        iCount++;
    }
    dataTable.DefaultView.Sort = "SortOrder Asc";
    dataTable = dataTable.DefaultView.ToTable();
