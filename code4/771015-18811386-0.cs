    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            ModifyList(ref test.Source);
            //Why here test.Source.Count() == 3 ? Why isn't it null ?
        }
    
        private static void ModifyList(ref List<string> list)
        {
            list.Add("Three");
            list = null;
        }
    }
