    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<DataRow> rows = new[]
            {
                new DataRow(1,"fish",""),
                new DataRow(1,"fish","D"),
                new DataRow(2,"cat","A"),
                new DataRow(3,"fox",""),
                new DataRow(3,"dog","U"),
                new DataRow(4,"mouse","")
            };
            var result = rows
                .GroupBy(x => x.Id)
                .Select(g => new 
                {
                    Count = g.Count(),
                    Id = g.First().Id,
                    FirstRow = g.First(),
                    LastRow = g.Last() 
                }).Select(item => new 
                {
                    RowId = item.Id,
                    OldData = item.Count == 1 && item.FirstRow.RowMod != "" ? null : item.FirstRow.Data,
                    NewData = item.LastRow.RowMod == "D" ? null : item.LastRow.Data,
                    RowMod = item.LastRow.RowMod 
                });
                //Or using query syntax
                var result2 = from x in rows
                              orderby x.Id, x.RowMod
                              group x by x.Id into g
                              select new
                              {
                                  RowId = g.First().Id,
                                  OldData = g.Count() == 1 && g.First().RowMod != "" ? null : g.First().Data,
                                  NewData = g.Last().RowMod == "D" ? null : g.Last().Data,
                                  RowMod = g.Last().RowMod
                              };
            // Test
            Console.WriteLine("RowID\tOldData\tNewData\tRowMod");
            foreach (var item in result)
            {
                Console.WriteLine("{0}\t'{1}'\t'{2}'\t'{3}'",item.RowId,item.OldData ?? "null",item.NewData ?? "null",item.RowMod);
            }
        }
    }
    public class DataRow
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string RowMod { get; set; }
        public DataRow(int id, string data, string rowMod)
        {
            Id = id;
            Data = data;
            RowMod = rowMod;
        }
    }
