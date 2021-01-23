    class Program
    {
        static void Main(string[] args)
        {
            MyWrapper wrapper = new MyWrapper();
            wrapper.Add("foo", "bar");
            wrapper.Add("fizz", "bang");
            // serialize single wrapper instance
            string json = JsonConvert.SerializeObject(wrapper, Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine();
            // deserialize single wrapper instance
            wrapper = JsonConvert.DeserializeObject<MyWrapper>(json);
            foreach (KeyValuePair<string, string> kvp in wrapper)
            {
                Console.WriteLine(kvp.Key + "=" + kvp.Value);
            }
            Console.WriteLine();
            Console.WriteLine("----------\n");
            MyWrapper wrapper2 = new MyWrapper();
            wrapper2.Add("a", "1");
            wrapper2.Add("b", "2");
            wrapper2.Add("c", "3");
            List<MyWrapper> list = new List<MyWrapper> { wrapper, wrapper2 };
            // serialize list of wrappers
            json = JsonConvert.SerializeObject(list, Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine();
            // deserialize list of wrappers
            list = JsonConvert.DeserializeObject<List<MyWrapper>>(json);
            foreach (MyWrapper w in list)
            {
                foreach (KeyValuePair<string, string> kvp in w)
                {
                    Console.WriteLine(kvp.Key + "=" + kvp.Value);
                }
                Console.WriteLine();
            }
        }
    }
