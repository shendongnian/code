    using (DataTable table = new DataTable())
    {
        table.Columns.Add("Id", typeof(int));
        table.Columns.Add("Price", typeof(decimal));
        table.Rows.Add(1231, 100M);
        table.Rows.Add(1232, 150M);
        table.Rows.Add(1235, 150M);
        //Add a new computed column:              expr
        table.Columns.Add("Flag", typeof(int), "[id] % 10");
        foreach (DataRow row in table.Rows)
        {
            Debug.WriteLine("{0}    {1}    {2}", row.ItemArray);
        }
    }
