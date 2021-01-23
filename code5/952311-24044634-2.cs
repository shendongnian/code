    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass { MyDict = new Dictionary<string, int>() };
            mc.MyDict.Add("One", 1);
            mc.MyDict.Add("Two", 2);
            string json = JsonConvert.SerializeObject(mc, Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine();
            MyClass mc2 = JsonConvert.DeserializeObject<MyClass>(json);
            foreach (KeyValuePair<string, int> kvp in mc2.MyDict)
            {
                Console.WriteLine(kvp.Key + " == " + kvp.Value);
            }
        }
    }
