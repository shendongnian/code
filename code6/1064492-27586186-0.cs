    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["Rainbow"] = new ColorHolder { Value = Color.FromArgb(10, 20, 30, 40) };
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(dict, settings);
            Console.WriteLine(json);
            Console.WriteLine();
            var d = JsonConvert.DeserializeObject<Dictionary<string, object>>(json, settings);
            ColorHolder holder = (ColorHolder)d["Rainbow"];
            Console.WriteLine("A=" + holder.Value.A);
            Console.WriteLine("R=" + holder.Value.R);
            Console.WriteLine("G=" + holder.Value.G);
            Console.WriteLine("B=" + holder.Value.B);
        }
    }
