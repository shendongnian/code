    results = (from row in datatableMasterA.AsEnumerable()
                 group row by new
                 {
                     symbol = row.Field<string>("BloombergSymbol"),
                     desc  = row.Field<string>("Description")
                 }
                 into grp
                 select new MyClass()
                 {
                     Symbol = (string)grp.Key.symbol,
                     Description = (string)grp.Key.desc,
                     //etc...
                }).ToList();
