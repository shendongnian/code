    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { Name = "Joe", Age = 26 };
            Console.WriteLine("Etag = " + p.ETag);
            Console.WriteLine();
            Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented));
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string ETag
        {
            get { return JsonHelper.Hash(JsonHelper.Serialize(this, "ETag")); }
        }
    }
