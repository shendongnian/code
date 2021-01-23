    List<HeaderClass> x = (from row in table.AsEnumerable()
            group row by row.Field<string>("Header") into hdr
            select new HeaderClass
            {
                Header = hdr.First().Field<string>("Header"),
                RowHeader = (from hdrrow in hdr
                            group hdrrow by hdrrow.Field<string>("RowHeader") into row
                            select new RowHeaderClass
                            {
                                Header = row.First().Field<string>("RowHeader"),
                                RowItems = from itemrow in row
                                            select new RowItemsClass
                                            {
                                                Item1 = itemrow.Field<string>("Items").Split(',')[0],
                                                Item2 = itemrow.Field<string>("Items").Split(',')[1]
                                            }
                            }).ToList()
            }).ToList();
