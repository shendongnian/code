        if (datset2.Rows.Count == 0)
        {
            datset2 = new DataTable();
            datset2.Columns.Add("Message", typeof(string));
            datset2.Rows.Add("No items found");
        }
