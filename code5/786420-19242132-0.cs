    class Program
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<int, StringBuilder>();
    
            //Initialize dictionary
            for (int i = 0; i < 10; i++)
            {
                dic.Add(i, new StringBuilder());
            }
    
            TimerElapsed(dic);
    
            TimerElapsed(dic);
    
            Process(dic.Values.ToArray());
        }
    
        public static void Process(object[] objects)
        {
            //Do your processing
        }
    
        public static void TimerElapsed(IDictionary<int, StringBuilder> dic)
        {
            for (int i = 0; i < 10; i++)
            {
                dic[i].Append(i.ToString());
            }
        }
    }
