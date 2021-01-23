     class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            i = QueryRecords(i);
        }
        private static int QueryRecords(int i)
        {
            using (YourEntityModel db = new YourEntityModel())
            {
                var query = (from p in db.Plants
                             select p).OrderBy(x => x.TownName).Skip(i).Take(10000);
                if (query.Count() >= 1)
                {
                    ProcessRecords(i, query);
                }
                else
                {
                    Console.WriteLine("Reached end of records");
                    Console.ReadLine();
                }
            }
            return i;
        }
        private static void ProcessRecords(int i, IQueryable<Plants> query)
        {
            foreach (Plants item in query)
            {
                    //Do your transform
                    //    item.PlantHeight = PlantHeight **converted to inches**
                    //db.SaveChanges();
            }
            i = i + 10000;
            QueryRecords(i);
        }
    }
