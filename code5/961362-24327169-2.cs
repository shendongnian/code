    class Program
    {
        static void Main(string[] args)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            JsonTextWriter jsonWriter = new JsonTextWriter(new StreamWriter("Output.json"));
            JsonItemWriter itemWriter = new JsonItemWriter(jsonWriter, jsonSerializer);
            MockDataGatherer gatherer = new MockDataGatherer();
            gatherer.ItemGathered += item =>
            {
                itemWriter.WriteItem(item);
            };
            var items = new[]
            {
                new { Id = 218515, Name = "A" },
                new { Id = 118647, Name = "B" }
            };
            gatherer.SimulateReceivingItems(items);
            itemWriter.Close();
            using (StreamReader reader = new StreamReader("Output.json"))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
    class MockDataGatherer
    {
        public void SimulateReceivingItems(IEnumerable<object> items)
        {
            foreach (object item in items)
            {
                ItemGathered(item);
            }
        }
        public event ItemGatheredEventHandler ItemGathered;
        public delegate void ItemGatheredEventHandler(object item);
    }
