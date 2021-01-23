    class Program
    {
        private static void Main ()
        {
            var m = new Manager { Attr = "Attr1" };
            var e = new Employee { Attr = "Attr1", Manager = m };
            m.Employees = new[] { e };
            Console.WriteLine(JsonConvert.SerializeObject(m,
                new JsonSerializerSettings {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                }));
            Console.ReadKey();
        }
    }
    class Manager
    {
        public Employee[] Employees;
        public string Attr;
    }
    class Employee
    {
        public Manager Manager;
        public string Attr;
    }
