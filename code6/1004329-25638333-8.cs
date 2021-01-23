    DataTable tbl = new DataTable();
            tbl.Columns.Add("LastName", typeof(string));
            tbl.Columns.Add("FirstName", typeof(string));
            tbl.Columns.Add("AnnualRate", typeof(string));
            foreach (var item in fn)
            {
                tbl.Columns.Add(item.Key.ToString(),typeof(string));
            }
