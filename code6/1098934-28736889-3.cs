    class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, string> dict = new SortedList<int, string>();
            dict.Add(22, "Entry22");
            dict.Add(11, "Entry11");
            //forward
            Console.WriteLine("Forward:");
            foreach (var item in dict)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value );
            }
            //backward
            Console.WriteLine("Backward:");
            foreach (var item in dict.Reverse())
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value );
            }
        }
    }
