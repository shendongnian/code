     var result = from sqlDataRows in sqlDataTable.AsEnumerable()
                        join mySqlDataRows in mySqlDataTable.AsEnumerable()
                            on sqlDataRows.Field<string>("UserID") equals mySqlDataRows.Field<string>("SiteUserID") into lj
                        from r in lj.DefaultIfEmpty()
                        select dtResult.LoadDataRow(new object[]
                        {
                            r.Field<int>("UserID"),
                            r.Field<string>("Field1"),
                            r == null ? 0 : r.Field<int>("Field2")
                            //The name 'mySqlDataRows' does not exist in the current context 
                        }, false);
