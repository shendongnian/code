    namespace ConsoleApplication1
    {
        class ClassA
        {
            public string ClassAProp { get; set; }
        }
    
        class ClassB : ClassA
        {
            public string ClassBProp { get; set; }
        }
    
        class ClassC : ClassB
        {
            public string ClassCProp { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var c = new ClassC();
                var t = c.GetType();
                while (t.BaseType != null)
                {
                    var cProps = t.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                    foreach (var p in cProps)
                    {
                        Console.WriteLine("{0} defines {1}", t.Name, p.Name);
                    }
                    t = t.BaseType;
                }
                Console.ReadLine();
            }
        }
    }
