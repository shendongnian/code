       class special
       {
            public string something = "";
       }
        class Program
        {
            static void Main(string[] args)
            {
                List<special> list = new List<special>();
    
                List<string> stringlist = list.ConvertAll(c => c.something);    
            }
        }
