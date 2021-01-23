    class Program
    {
        static void Main(string[] args)
        {
            DeserializeAndDump<DeserializedJsonAPI1>(1, @"{""field_1"":""q"",""field_007"":""r"",""field_3"":""s""}");
            DeserializeAndDump<DeserializedJsonAPI2>(2, @"{""field_1"":""x"",""field_2"":""y"",""field_007"":""z""}");
        }
        private static void DeserializeAndDump<T>(int n, string json) where T : DeserializedJson
        {
            Console.WriteLine("--- API " + n + " ---");
            DeserializedJson obj = JsonConvert.DeserializeObject<T>(json);
            Console.WriteLine("field_1: " + obj.field_1);
            Console.WriteLine("field_2: " + obj.field_2);
            Console.WriteLine("field_3: " + obj.field_3);
            Console.WriteLine();
        }
    }
