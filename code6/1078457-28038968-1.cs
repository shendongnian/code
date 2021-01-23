    var result = from a in tableA.AsEnumerable()
                 from b in tableB.AsEnumerable()
                 where a.Field<string>("ACol1") == b.Field<string>("BCol1")
                    || a.Field<string>("ACol1") == b.Field<string>("BCol2")
                 select new
                        {
                            a.Field<string>("ACol1"),
                            a.Field<string>("ACol2"),
                            a.Field<string>("ACol3"),
                            b.Field<string>("BCol3")
                        };
