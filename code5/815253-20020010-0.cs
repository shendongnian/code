    class Program
    {
        public static Dictionary<string, int> mcollection = new Dictionary<string, int>() { { "565", 5 }, { "34", 1 }, { "78", 9 } };
        public static List<string> mybuylist = new List<string>() { "34", "45", "58" };
        static void Main(string[] args)
        {
            foreach (string entry in mybuylist)
            {
                if (mcollection.ContainsKey(entry))
                {
                    Console.WriteLine(entry);
                    //dosomething                     
                }
            }
        }
    }
    O/P: 34
