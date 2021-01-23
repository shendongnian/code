    DataTable table =
        new DataTable  // <-- IMPORTANT
        {
            Columns = { { "Name", typeof(string) } },  // table.Columns.Add("Name", typeof(string));
            Rows = { "John" },                         // table.Rows.Add("John");
        };
