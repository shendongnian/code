    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> rows = new List<List<string>>
            {
                new List<string>
                {
                    "A",
                    null,
                    ""
                },
                new List<string>
                {
                    null,
                    "B",
                    ""
                },
                new List<string>
                {
                    "",
                    null,
                    "C"
                }
            };
            string json = JsonConvert.SerializeObject(rows);
            Console.WriteLine(json);
        }
    }
