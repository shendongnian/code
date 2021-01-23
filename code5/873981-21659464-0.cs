    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
            Console.Read();
        }
    
        void Run()
        {
            AssemblyCatalog catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
    
            Dictionary<IClass, List<Func<int>>> dictionary = new Dictionary<IClass, List<Func<int>>>();
    
            IEnumerable<IClass> classes = container.GetExportedValues<IClass>();
            IEnumerable<Func<int>> methods = container.GetExportedValues<Func<int>>();
    
            foreach(var c in classes)
            {
                dictionary[c] = new List<Func<int>>();
            }
    
            foreach(var m in methods)
            {
                dictionary[(IClass)m.Target].Add(m);
            }            
    
            foreach(var kvp in dictionary)
            {
                kvp.Value.ForEach(m => Console.WriteLine(m()));
            }
        }
    }
