            var Table1 = new List<Row>();
            for (int i = 0; i < 10; i++)
            {
                for (int m = 0; m < 5; m++)
                {
                    for (int x = 0; x < i + m; x++)
                    {
                        Table1.Add(new Row() { Id = m });
                    }
                }
            }
            var result = Table1.GroupBy(row => row.Id)
                        .Where(p => p.Count() > 1);
            var resultB = from row in Table1
                          group row by row.Id into rowGrouped
                          where rowGrouped.Count() > 1
                          select rowGrouped;
            foreach (var r in resultB)
            {
                Console.WriteLine("ID {0} count: {1}", r.Key, r.Count());
            }
