    bool matchFound =table1.AsEnumerable()
                            .Select(row1 => row1.Field<int>("ID"))
                        .Intersect(
                            table2.AsEnumerable()
                            .Select(row2 => row2.Field<int>("ID)))
                            .Any();
