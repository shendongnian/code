    class Program
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Lists...");
            var stringList = new List<string>();
            var hashList = new HashSet<string>();
            var sortedList = new SortedSet<string>();
            var searchWords1 = new string[3];
            int ndx = 0;
            for (int x = 0; x < 1000000; x++)
            {
                string str = RandomString(10);
                if (x == 5 || x == 500000 || x == 999999)
                {
                    str = "Z" + str;
                    searchWords1[ndx] = str;
                    ndx++;
                }
                stringList.Add(str);
                hashList.Add(str);
                sortedList.Add(str);
            }
            Console.WriteLine("Lists created!");
            var sw = new Stopwatch();
            sw.Start();
            bool search1 = stringList.Contains(searchWords1[2]);
            sw.Stop();
            Console.WriteLine("List<T> {0} ==> {1}ms", search1, sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            search1 = hashList.Contains(searchWords1[2]);
            sw.Stop();
            Console.WriteLine("HashSet<T> {0} ==> {1}ms", search1, sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            search1 = sortedList.Contains(searchWords1[2]);
            sw.Stop();
            Console.WriteLine("SortedSet<T> {0} ==> {1}ms", search1, sw.ElapsedMilliseconds);
        }
        private static string RandomString(int size)
        {
            var builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
