    // Fill Employee names in each row
    string fullName = "";
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        if (dt.Rows[i][0].ToString() != "")
        {
            fullName = dt.Rows[i][0].ToString();
        }
        else
        {
            dt.Rows[i][0] = fullName;
        }
    }
    
    // Split into tables by each employee
    List<DataTable> employeesTables = dt.AsEnumerable()
                            .GroupBy(row => row.Field<string>("F1"))
                            .Select(g => g.CopyToDataTable())
                            .ToList();
