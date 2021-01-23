        public partial class TermBucket
        {
            public short ID { get; set; }
            public byte Period { get; set; }
            public byte Min { get; set; }
            public byte Max { get; set; }
        }
        static void Main(string[] args)
        {
            List<TermBucket> l = new List<TermBucket>();
            l.Add(new TermBucket() { ID = 1, Period = 3, Min = 10, Max = 14 });
            l.Add(new TermBucket() { ID = 1, Period = 4, Min = 10, Max = 13 });
            l.Add(new TermBucket() { ID = 1, Period = 5, Min = 100, Max = 25 });
            l.Add(new TermBucket() { ID = -1, Period = 3, Min = 10, Max = 12 });
            int period = 3;
            int minV = 10;
            int maxV = 13;
            var res = from e in l 
                      join e2 in l on e.ID equals e2.ID
                      where e.Period == period && minV >= e.Min && maxV <= e.Max 
                      select e2;
            foreach (var r in res)
            {
                Console.WriteLine(r.ID + " " + r.Period);
            }
            
            Console.ReadLine();
        }
