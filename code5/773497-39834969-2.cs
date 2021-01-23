    private DataTable getDurationTypes()
    {
        DataTable table = new DataTable();
		table.Columns.Add("DurationTypeID", typeof(int));
		table.Columns.Add("DurationTypeName", typeof(string));
		table.Rows.Add(1, "Hours");
		table.Rows.Add(2, "Days");
		table.Rows.Add(3, "Weeks");
		table.Rows.Add(4, "Months");
		return table;
     }
