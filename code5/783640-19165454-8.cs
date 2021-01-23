    class Program
    {
        static void Main(string[] args)
        {
            ObjA a = new ObjA();
            a.Id = 123;
            a.OtherStuff = "other stuff A";
            ObjB b = new ObjB();
            b.Id = 456;
            b.OtherStuff = "other stuff B";
            b.MyParent = a;
            a.MyChild = b;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(a, settings);
            Console.WriteLine(json);
        }
    }
