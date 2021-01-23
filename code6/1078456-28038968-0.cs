    var result = from a in tableA
                 from b in tableB
                 where a.ACol1 == b.BCol1 || a.ACol1 == b.BCol2
                 select new
                        {
                            a.ACol1,
                            a.ACol2,
                            a.ACol3,
                            b.BCol3
                        };
