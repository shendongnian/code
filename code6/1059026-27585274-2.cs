    class Program
    {
        static void Main(string[] args)
        {
            List<MyObject> list = new List<MyObject>
            {
                new MyObject { MyValue = TimeSpan.FromDays(2) },
                new MyObject { MyValue = "foo" },
                new MyObject { MyValue = new DateTime(2014, 12, 20, 17, 06, 44) },
                new MyObject { MyValue = new Tuple<int, bool>(23, true) }
            };
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine();
            list = JsonConvert.DeserializeObject<List<MyObject>>(json);
            foreach (MyObject obj in list)
            {
                Console.WriteLine(obj.MyValue.GetType().Name + ": " + obj.MyValue.ToString());
            }
        }
    }
