    class Program
        {
            class A
            {
                public A(){}
                public int? ID { get; set; }
            }
            static void Main(string[] args)
            {
                var listA = new List<A>
                    {
                        new A(){ID = null},
                        new A(){ID = 2},
                        new A(){ID = null},
                        new A(){ID = 3},
    
                    };
    
                var result = listA.OrderByDescending(x => x.ID != null).ThenBy(x => x.ID);
    
                foreach (var a in result)
                {
                    Console.WriteLine(a.ID);
                }
    
            }
        }
