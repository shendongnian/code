    var q = from row in TableCCY1.AsEnumerable().Concat(TableCCY2.AsEnumerable())
            group row by new
            {
                CCY1 = row.Field<string>("CCY1"),
                PCode = row.Field<string>("PCODE")
            } into matches
            select new
            {
                CCY1 = matches.Key.CCY1,
                PCODE = matches.Key.PCode,
                Sum = matches.Sum(match => match.Field<decimal?>("AMT2")),
            };
