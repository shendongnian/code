            var table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Rows.Add("Sample Name");
            table.AcceptChanges();
            table.Rows[0].SetField("Name", "Sample Name");
            table.AcceptChanges(); //called here
            var changes = table.GetChanges();
