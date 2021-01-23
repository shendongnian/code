    foreach (var column in ds.Tables[0].Columns.Cast<DataColumn>().ToArray())
            {
                if (ds.Tables[0].AsEnumerable().All(dr => dr.IsNull(column)))
                {
                    ds.Tables[0].Columns.Remove(column);
                }
            }
