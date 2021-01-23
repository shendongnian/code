    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> dataList = new List<List<string>>();
            dataList.Add(new List<string> { "00000", "Mimzi Dagger", "100", "50", "75", "70", "45",    "10", "98", "83" });
            dataList.Add(new List<string> { "00001", "Alexander Druaga", "89", "45", "80", "90", "15", "73", "99", "100", "61" });
            dataList.Add(new List<string> { "00002", "Nicholas Zarcoffsky", "100", "50", "80", "50", "75", "100", "100" });
            dataList.Add(new List<string> { "00003", "Kantmiss Evershot", "50", "100" });
            for (int i = 0; i < dataList.Count; i++)
            {
                foreach (var item in dataList[i])
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadLine();
        }
    }
