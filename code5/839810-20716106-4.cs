    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""Foo"" : 1,
                ""Foo"" : [2],
                ""Foo"" : [3, 4],
                ""Bar"" : { ""X"" : [ ""A"", ""B"" ] },
                ""Bar"" : { ""X"" : ""C"", ""X"" : ""D"" },
            }";
            using (StringReader sr = new StringReader(json))
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
                JToken token = DeserializeAndCombineDuplicates(reader);
                Dump(token, "");
            }
        }
        private static void Dump(JToken token, string indent)
        {
            Console.Write(indent);
            if (token == null)
            {
                Console.WriteLine("null");
                return;
            }
            Console.Write(token.Type);
    
            if (token is JProperty)
                Console.Write(" (name=" + ((JProperty)token).Name + ")");
            else if (token is JValue)
                Console.Write(" (value=" + token.ToString() + ")");
    
            Console.WriteLine();
    
            if (token.HasValues)
                foreach (JToken child in token.Children())
                    Dump(child, indent + "  ");
        }
    }
