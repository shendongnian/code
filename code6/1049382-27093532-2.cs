    class MyData
    {
        public string Foo { get; set; }
        [JsonConverter(typeof(UnknownObjectConverter))]
        public object UserProp { get; set; }
        [JsonConverter(typeof(UnknownObjectConverter))]
        public object UserProp2 { get; set; }
        public string Bar { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""Foo"": ""fizz"",
                ""UserProp"": {
                    ""$type"": ""System.Tuple`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"",
                    ""Item1"": ""pow""
                },
                ""UserProp2"": {
                    ""$type"": ""JsonTest.Something, JsonTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"",
                    ""Baz"": ""whiff""
                },
                ""Bar"": ""bang""
            }";
            MyData data = JsonConvert.DeserializeObject<MyData>(json);
            Console.WriteLine(data.Foo);
            Console.WriteLine(data.Bar);
            Console.WriteLine(((Tuple<string>)data.UserProp).Item1);
            Console.WriteLine(data.UserProp2 == null ? "null" : data.UserProp2.GetType().Name);
        }
    }
