    class Program
    {
        static void Main(string[] args)
        {
            List<Record> testData = new List<Record>()
            {
                new Record() { Type = 'a', Data="Data" },
                new Record() { Type = 'x', Data="Data" },
                new Record() { Type = 'b', Data="Data" },
                new Record() { Type = 'a', Data="Data" },
                new Record() { Type = 'x', Data="Data" },
                new Record() { Type = 'x', Data="Data" },
                new Record() { Type = 'x', Data="Data" },
                new Record() { Type = 'x', Data="Data" },
                new Record() { Type = 'x', Data="Data" },
                new Record() { Type = 'x', Data="Data" },
                new Record() { Type = 'b', Data="Data" },
                new Record() { Type = 'a', Data="Data" },
                new Record() { Type = 'x', Data="Data" },
                new Record() { Type = 'x', Data="Data" },
                new Record() { Type = 'x', Data="Data" },
                new Record() { Type = 'b', Data="Data" }
            };
            List<List<Record>> result = new List<List<Record>>();
            IEnumerable<Record> workingData = testData;
            while (workingData.Count() > 0)
            {
                IEnumerable<Record> subList = workingData.Take(1).Concat(workingData.Skip(1).TakeWhile(c => c.Type != 'a'));
                result.Add(subList.ToList());
                workingData = workingData.Except(subList);
            }
            Console.ReadKey();
        }
    }
    class Record
    {
        public char Type;
        public String Data;
    }
