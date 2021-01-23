    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""ChildObject1"": 
                {
                    ""Id"": ""key1"",
                    ""Name"": ""Foo Bar Baz""
                },
                ""ChildObject2"": ""key2""
            }";
            MyObject obj = JsonConvert.DeserializeObject<MyObject>(json);
            DumpChildObject("ChildObject1", obj.ChildObject1);
            DumpChildObject("ChildObject2", obj.ChildObject2);
            DumpChildObject("ChildObject3", obj.ChildObject3);
        }
        static void DumpChildObject(string prop, ChildObject obj)
        {
            Console.WriteLine(prop);
            if (obj != null)
            {
                Console.WriteLine("   Id: " + obj.Id);
                Console.WriteLine("   Name: " + obj.Name);
                Console.WriteLine("   IsFullyPopulated: " + obj.IsFullyPopulated);
            }
            else
            {
                Console.WriteLine("   (null)");
            }
            Console.WriteLine();
        }
    }
