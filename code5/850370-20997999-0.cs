    class Program
    {
        static void Main(string[] args)
        {
            List<StringContainer> strContainers = new List<StringContainer>();
            for (int i = 0; i < 1100; i++)
            {
                strContainers.Add(new StringContainer() { str = "string" + i });
            }
            Parallel.ForEach(
                strContainers,
                new ParallelOptions() { MaxDegreeOfParallelism = 4 },
                x => ProcessString(x));
            foreach (var item in strContainers)
            {
                Console.WriteLine(item.str);
            }
            Console.ReadKey();
        }
        private static void ProcessString(StringContainer strContainer)
        {
            strContainer.str += "_processed";
        }
    }
    public class StringContainer
    {
        public string str;
    }
