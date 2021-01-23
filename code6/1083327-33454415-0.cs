    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{ ""name"": ""foo"", ""size"": ""10"" }";
            MemoryStream inputStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            JsonSerializer serializer = new JsonSerializer();
            using (var textReader = new StreamReader(inputStream))
            {
                for (int i = 0; i < 2; i++)
                {
                    inputStream.Position = 0;
                    using (var reader = new JsonTextReader(textReader))
                    {
                        reader.CloseInput = false;
                        Widget w = serializer.Deserialize<Widget>(reader);
                        Console.WriteLine("Name: " + w.Name);
                        Console.WriteLine("Size: " + w.Size);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
    class Widget
    {
        public string Name { get; set; }
        public int Size { get; set; }
    }
