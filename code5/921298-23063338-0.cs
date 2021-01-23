    var Result = (from r1 in MyTable.AsEnumerable()
                join r2 in MySecondTable.AsEnumerable()
                on r1["ColName1"] equals r2["ColName2"]
                select new
                {
                    r1,
                    r2
                    // or choose columns
                }).ToList();
