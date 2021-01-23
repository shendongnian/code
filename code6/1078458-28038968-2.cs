    var result = from a in tableA.AsEnumerable()
                 from b in tableB.AsEnumerable()
                 where a.Field<string>("ACol1") == b.Field<string>("BCol1")
                    || a.Field<string>("ACol1") == b.Field<string>("BCol2")
                 select new
                        {
                            a["ACol1"],
                            a["ACol2"],
                            a["ACol3"],
                            b["BCol3"]
                        };
