            static void Main(string[] args)
            {
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    
                var implementor = string.Concat(Directory.GetCurrentDirectory(), @"\Implementations\Calculator.dll");
                var implementorBytes = File.ReadAllBytes(implementor);
    
                AppDomain.CurrentDomain.Load(implementorBytes);
    
                var obj = GetObject<IAdd>();
                Console.WriteLine(obj.SumNew(2, 2));
            }
    
            static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                if (args.Name.StartsWith("CalculatorDependency"))
                {
                    var dependency = string.Concat(Directory.GetCurrentDirectory(), @"\Implementations\CalculatorDependency.dll");
                    var dependencyBytes = File.ReadAllBytes(dependency);
    
                    return Assembly.Load(dependencyBytes);    
                }
    
                return null;
            }
    
            public static T GetObject<T>()
            {
                var t = typeof(T);
                
                var objects = (
                    from assembly in AppDomain.CurrentDomain.GetAssemblies()
                    from type in assembly.GetExportedTypes()
                    where typeof(T).IsAssignableFrom(type) && !type.FullName.Equals(t.FullName)
                    select (T)Activator.CreateInstance(type)
                ).ToArray();
    
                return objects.FirstOrDefault();
            }
