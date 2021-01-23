     class Program
        {
            static void Main(string[] args)
            {
                var listSecurityInfo = new List<SecurityInfo>();
                var listClassiNode = new List<ClassiNode>();
                initList(listSecurityInfo, listClassiNode);
                var sw = System.Diagnostics.Stopwatch.StartNew();
                var matched = listSecurityInfo.Where(c => listClassiNode.Any(d =>  c.SX == d.Exch && c.Instrument == d.Instrument)).ToList();
                sw.Stop();
                Console.WriteLine("took: " + sw.ElapsedMilliseconds + "ms matched: " +matched.Count());
                Console.Read();
            }
            private static void initList(List<SecurityInfo> listSecurityInfo, List<ClassiNode> listClassiNode)
            {
                var rnd = new Random();
                for (int i = 0; i < 12000; ++i)
                {
                    listSecurityInfo.Add(new SecurityInfo()
                    {
                        SX = new string(Convert.ToChar(rnd.Next(40, 125)), 4000),
                        Instrument = new string(Convert.ToChar(rnd.Next(40, 125)), 4000)
                    });
                }
                for (int i = 0; i < 12000; ++i)
                {
                    listClassiNode.Add(new ClassiNode()
                    {
                        Exch = new string(Convert.ToChar(rnd.Next(40, 125)), 4000),
                        Instrument = new string(Convert.ToChar(rnd.Next(40, 125)), 4000)
                    });
                }
            }
        }
