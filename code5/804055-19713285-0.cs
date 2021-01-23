                DataTable dt = new DataTable();
                dt.Columns.Add("Column1");
                dt.Columns.Add("Column2");
                dt.Rows.Add(1, "first");
                dt.Rows.Add(2, "second");
                var dictionary = dt.Rows.OfType<DataRow>().ToDictionary(d => d.Field<string>(0), v => v.Field<object>(1));
