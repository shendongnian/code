    var query = from r in source.AsEnumerable()
                let i = new
                {
                    TableName = r.Field<string>("TableName"),
                    Id = r.Field<int>("RowId"),
                    ColumnName = r.Field<string>("ColumnName"),
                    ColumnValue = r.Field<string>("ColumnValue")
                }
                group i by new { i.TableName, i.Id } into g
                select g;
