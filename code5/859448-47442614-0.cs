        class Some
        {
            public String text { get; set; }
                   
            public Some(String text)
            {
                this.text = text;
            }
            public override string ToString()
            {
                return text;
            }
        }
        public static MemoryCache cache = new MemoryCache("cache");
       
        public static string cache_name = "mycache";
        static void Main(string[] args)
        {
            
            Some some1 = new Some("some1");
            Some some2 = new Some("some2");
            List<Some> list = new List<Some>();
            list.Add(some1);
            list.Add(some2);
            do {
                            
                if (cache.Contains(cache_name))
                {
                    Console.WriteLine("Getting from cache!");
                    List<Some> list_c = cache.Get(cache_name) as List<Some>;
                    foreach (Some s in list_c) Console.WriteLine(s);
                }
                else
                {
                    Console.WriteLine("Saving to cache!");
                    cache.Set(cache_name, list, DateTime.Now.AddMinutes(10));                   
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
