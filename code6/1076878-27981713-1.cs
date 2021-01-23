    namespace ConsoleApplication
    {
        public class Test
        {
            public string name { get; set; }
            public int count { get; set; }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                    List<Test> testList = new List<Test>();
                    testList.Add(new Test { name = "yes", count = 1 });
                    testList.Add(new Test { name = "no", count = 0 });
                    testList.Add(new Test { name = "can't say", count = 3 });
    
    
                    var totalCount = testList.Sum(c => c.count);
    
                    foreach(var item in testList)
                    {
                        Console.WriteLine(string.Format("{0} {1}", (decimal)item.count / totalCount * 100, item.name));
                    }
    
                    Console.ReadKey();
            }
        }
    }
