        private static Dictionary<string, Func<DataContext, IEnumerable<lst>>> functions = new Dictionary<string, Func<DataContext, IEnumerable<lst>>>() 
        { 
            {"A", 
             delegate(DataContext dbCtx)
             {
                return new List<lst>(); // your query here...
             }
            },
            {"B", 
             delegate(DataContext dbCtx)
             {
                return new List<lst>();
             }
            },
            {"C", 
             delegate(DataContext dbCtx)
             {
                return new List<lst>();
             }
            }
        };
        public IEnumerable<string> fnc(string category)
        {
            if (!(functions.ContainsKey(category)))
            {
                throw new NotImplementedException();
            }
            using(Context sample = new Context()
            {
                return functions[category].Invoke(sample);
            }
        }
