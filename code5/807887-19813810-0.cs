        var singOneJoin =
            from prod in singOneProd.Table.AsEnumerable()
            join agg in singOneAgg.Table.AsEnumerable()
            on new {
                Print = prod.Field<string>("print"),
                Id3 = prod.Field<Int32>("id3")
            } equals new {
                Print = agg.Field<string>("print"),
                Id3 = agg.Field<Int32>("id3")
            } 
            select new {
                print = prod.Field<string>("print")
            };
