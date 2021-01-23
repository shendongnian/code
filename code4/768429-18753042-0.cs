    static void Main(string[] args)
        {
            ClassOfKb KbA = new ClassOfKb();
            ClassOfKb KbB = new ClassOfKb();
            // Test data --------
            Data data1 = new Data() { ID = Guid.NewGuid(), name = "111" };
            Data data2 = new Data() { ID = Guid.NewGuid(), name = "222" };
            Data data2_changed = new Data() { ID = data2.ID, name = "222_changed" };
            Data data3 = new Data() { ID = Guid.NewGuid(), name = "333" };
            Info info1 = new Info() { ID = Guid.NewGuid(), text = "aaa" };
            Info info2 = new Info() { ID = Guid.NewGuid(), text = "bbb" };
            Info info2_changed = new Info() { ID = info2.ID, text = "bbb_changed" };
            Info info3 = new Info() { ID = Guid.NewGuid(), text = "ccc" };
            KbA.KbData.Add(data1);
            KbA.KbData.Add(data2);
            KbA.KbInfo.Add(info1);
            KbA.KbInfo.Add(info2);
            KbB.KbData.Add(data2_changed);
            KbB.KbData.Add(data3);
            KbB.KbInfo.Add(info2_changed);
            KbB.KbInfo.Add(info3);
            // end of test data ---------
            // here is the solution:
            var indexes = Enumerable.Range(0, KbA.KbData.Count);
            var deleted = from i in indexes
                          where !KbB.KbData.Select((n) => n.ID).Contains(KbA.KbData[i].ID)
                          select new
                          {
                              Name = KbA.KbData[i].name,
                              KbDataID = KbA.KbData[i].ID,
                              KbInfoID = KbA.KbInfo[i].ID
                          };
            Console.WriteLine("deleted:");
            foreach (var val in deleted)
            {
                Console.WriteLine(val.Name);
            }
            var added = from i in indexes
                        where !KbA.KbData.Select((n) => n.ID).Contains(KbB.KbData[i].ID)
                        select new
                        {
                            Name = KbB.KbData[i].name,
                            KbDataID = KbB.KbData[i].ID,
                            KbInfoID = KbB.KbInfo[i].ID
                        };
            Console.WriteLine("added:");
            foreach (var val in added)
            {
                Console.WriteLine(val.Name);
            }
            var changed = from i in indexes
                          from j in indexes
                          where KbB.KbData[i].ID == KbA.KbData[j].ID &&
                                (//KbB.KbData[i].file != KbA.KbData[j].file ||
                                KbB.KbData[i].name != KbA.KbData[j].name ||
                              //KbB.KbInfo[i].date != KbA.KbInfo[j].date ||
                                KbB.KbInfo[i].text != KbA.KbInfo[j].text
                                )
                          select new
                          {
                              Name = KbA.KbData[j].name,
                              KbDataID = KbA.KbData[j].ID,
                              KbInfoID = KbA.KbInfo[j].ID
                          };
            Console.WriteLine("changed:");
            foreach (var val in changed)
            {
                Console.WriteLine(val.Name);
            }
            Console.ReadLine();
        }
    }
    public class ClassOfKb
    {
        public List<Data> KbData = new List<Data>();
        public List<Info> KbInfo = new List<Info>();
    }
    public class Data
    {
        public Guid ID { get; set; }
        public byte[] file { get; set; }
        public string name { get; set; }
    }
    public class Info
    {
        public Guid ID { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
    }
