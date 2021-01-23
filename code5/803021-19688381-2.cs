    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new object[] { 
                new Product(){Id=1},
                new Variant(){Id=1}
            };
            Process(myList);
        }
        static void Process(object[] myList)
        {
            foreach (dynamic item in myList)
            {
                item.Id += 1;
            }
        }
    }
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Foo { get; set; }
    }
    class Variant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bar { get; set; }
    }
    pub
