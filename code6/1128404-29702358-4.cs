    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
               ""items"": [
                  [10, ""file1"", ""command 1""],
                  [20, ""file2"", ""command 2""],
                  [30, ""file3"", ""command 3""]
               ]
            }";
            Foo foo = JsonConvert.DeserializeObject<Foo>(json, new ItemConverter());
            foreach (Item item in foo.Items)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("File: " + item.File);
                Console.WriteLine("Command: " + item.Command);
                Console.WriteLine();
            }
        }
    }
    class Foo
    {
        public List<Item> Items { get; set; }
    }
    class Item
    {
        public int Id { get; set; }
        public string File { get; set; }
        public string Command { get; set; }
    }
