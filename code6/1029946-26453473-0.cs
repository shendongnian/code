    using System;
    using System.Web.Script.Serialization;
    class Program
    {
        static void Main(string[] args)
        {
            DerivedClass dc = new DerivedClass
            {
                Id = 1,
                Name = "foo",
                Size = 10.5
            };
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string json = ser.Serialize(dc);
            Console.WriteLine(json);
            Console.WriteLine();
            DerivedClass dc2 = ser.Deserialize<DerivedClass>(json);
            Console.WriteLine("Id: " + dc2.Id);
            Console.WriteLine("Name: " + dc2.Name);
            Console.WriteLine("Size: " + dc2.Size);
        }
    }
    class BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class DerivedClass : BaseClass
    {
        public double Size { get; set; }
    }
