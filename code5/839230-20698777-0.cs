    List<DataTable> tables = ds.Tables[0].AsEnumerable()
                               .GroupBy(row => new {
                                   Email = row.Field<string>("EMAIL"), 
                                   Name = row.Field<string>("NAME") 
                               }).Select(g => g.CopyToDataTable()).ToList();
