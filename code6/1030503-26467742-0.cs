    foreach (var column in ds.Tables[0].Columns.Cast<DataColumn>().ToArray())
            {
                if (ds.Tables[0].AsEnumerable().All(dr => dr[column] == 123)))
                {
                    ds.Tables[0].Columns.Remove(column);
                }
            }
