    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {  
                ""name"": ""david"",
                ""age"": 100,
                ""sex"": ""M"",
                ""address"": ""far far away""
            }";
            MyClass obj = JsonConvert.DeserializeObject<MyClass>(json);
            Console.WriteLine("orig name: " + obj.name);
            Console.WriteLine("orig age: " + obj.age);
            Console.WriteLine();
            obj.name = "john";
            obj.age = 200;
            json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
