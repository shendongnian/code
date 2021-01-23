    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("file.json");
            dynamic obj = JObject.Parse(json);
            Console.WriteLine(obj.collection.channel_id);
        }
    }
