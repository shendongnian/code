    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""result"" : 
                [
                    { ""a"" : ""a1"" },
                    { ""b"" : ""b1"" },
                    { ""c"" : ""c1"", ""d"" : ""d1"", ""a"" : ""a2"" },
                    { ""a"" : ""a3"", ""d"" : ""d2"" },
                    { ""b"" : ""b2"", ""c"" : ""c2"" },
                ]
            }";
            JObject jo = JObject.Parse(json);
            JArray ja = FillMissingProperties((JArray)jo["result"]);
            jo["result"] = ja;
            Console.WriteLine(jo.ToString());
        }
        public static JArray FillMissingProperties(JArray array)
        {
            // find all distinct property names across all objects in the array
            ISet<string> names = new SortedSet<string>();
            foreach (JObject obj in array.Children<JObject>())
            {
                foreach (JProperty prop in obj.Properties())
                {
                    names.Add(prop.Name);
                }
            }
            // copy objects to a new array, adding missing properties along the way
            JArray arrayOut = new JArray();
            foreach (JObject obj in array.Children<JObject>())
            {
                JObject objOut = new JObject();
                foreach (string name in names)
                {
                    JToken val = obj[name];
                    if (val == null)
                    {
                        val = new JValue("");
                    }
                    objOut.Add(name, val);
                }
                arrayOut.Add(objOut);
            }
            return arrayOut;
        }
    }
