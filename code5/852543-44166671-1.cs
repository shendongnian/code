            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("Id", typeof(long)));
    //i'm adding from a list passed as parameter; your example is via collection initializer
            foreach (var id in Ids)
            {
                dt.Rows.Add(id);
            }
