    public static dynamic GetAllDifferences (DataTable sourceTable,DataTable targetTable)
            {
                var source = sourceTable.AsEnumerable();
                var target = targetTable.AsEnumerable();
    
                var noMatchInSource = from dtSource in source
                    join dtTarget in target on dtSource.Field<int>("empid") equals dtTarget.Field<int>("empid")
                    where dtSource.Field<string>("firstname").Equals(dtTarget.Field<string>("firstname"))
                          && dtSource.Field<string>("lastname").Equals(dtTarget.Field<string>("lastname"))
                          && dtSource.Field<DateTime>("dob").Equals(dtTarget.Field<DateTime>("dob"))
                    select dtSource;
    
                var result =
                            from sourceDataRow in sourceTable.AsEnumerable()
                            where !(from noMatchDataRow in noMatchInSource
                                    select noMatchDataRow.Field<int>("empid"))
                                   .Contains(sourceDataRow.Field<int>("empid"))
                            select sourceDataRow;
                                    return result;
            }
