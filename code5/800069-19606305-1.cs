        public class Recipient
        {
            public Recipient()
            {
                Table = new List<Table>();
            }
            public long RecipientID { get; set; }
            public List<Table> Table { get; set; }
        }
        public class Table
        {
            public long TableID { get; set; }
            public long RecipientID { get; set; }
            public Recipient Recipient { get; set; }
        }
        private static void Add(List<Recipient> list, long index, int p2)
        {
            Recipient r = new Recipient
            {
                RecipientID = index
            };
            for (int i = 0; i < p2; i++)
            {
                Table t = new Table
                {
                    TableID = i,
                    Recipient = r,
                    RecipientID = r.RecipientID
                };
                r.Table.Add(t);
            }
            list.Add(r);
        }
        static void Main(string[] args)
        {
            List<Recipient> list = new List<Recipient>();
            Add(list, 1, 80);
            Add(list, 2, 15);
            Add(list, 3, 99);
            var listq = list
               .SelectMany(x => 
                   x.Table.Select( (y,i)=> new {
                      Key = y.RecipientID + "-" + ((int)i/(int)40),
                      Value = y
                   })
               );
            var model = listq.GroupBy(x=>x.Key)
               .Select( x=> new {
                   Recipient = x.Select(y=>y.Value.Recipient).First(),
                   Table = x.Select(y=>y.Value)
               });
            foreach (var item in model)
            {
                Console.WriteLine("{0}={1}",item.Recipient.RecipientID,item.Table.Count());
            }
            Console.ReadLine();
        }
