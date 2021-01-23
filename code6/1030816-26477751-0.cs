    class Program
    {
        static void Main(string[] args)
        {
            JObject jo = new JObject();
            jo.Add("ID", "9dbefe3f5424d972e040007f010038f2");
            // token is a JObject
            DumpToken(jo);
            // token is a JProperty (the first property of the JObject)
            DumpToken(jo.Properties().First());
            // token is a JValue (the value of the "ID" property in the JObject)
            DumpToken(jo["ID"]);  
        }
        private static void DumpToken(JToken token)
        {
            Console.WriteLine(token.GetType().Name);
            Console.WriteLine(token.ToString());
            Console.WriteLine();
        }
    }
