    internal class Program
        {
            public static void Main()
            {
                var strings = new List<Tuple<String, int>>()
                    {
                        new Tuple<String, int>("Hello", 4),
                        new Tuple<String, int>("World", 2),
                        new Tuple<String, int>("Cheese", 20)
                    };
    
                var queryableStrings = strings.AsQueryable();
    
                Expression<Func<Tuple<string, int>, bool>> cond = src => src.Item1.Length > src.Item2;
                
                var result = queryableStrings
                    .AsExpandable()
                    .Where(s => cond.Invoke(s))
                    .ToList();
            }
            
        }
