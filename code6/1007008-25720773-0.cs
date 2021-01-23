        class Class
        {
            public string A { get; set; }
            public string B { get; set; }
        }
        static Func<Class, string> GetLambda()
        {
            var parameter = Expression.Parameter(typeof(Class), "item");
            var property = Expression.Property(parameter, "A");
            var projection = Expression.Lambda<Func<Class, string>>(property, parameter);
    
            return projection.Compile();
        }
        static void Main(string[] args)
        {
            List<Class> list = new List<Class>();
            list.Add(new Class() { A = "class1-a", B = "class1-b" });
            list.Add(new Class() { A = "class2-a", B = "class2-b" });
            
            var select = list.Select(GetLambda()).ToList();
        }
