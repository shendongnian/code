    class Program
    {
        static void Main(string[] args)
        {
            var testPerson = CreatePerson(new[] { "Old", "Employed" });
            Console.WriteLine(testPerson.Old);
            Console.WriteLine(testPerson.Educated);
            Console.WriteLine(testPerson.Employed);
            Console.WriteLine(testPerson.Married);
        }
        public static Person CreatePerson(string[] args)
        {
            Person result = new Person();
            Type personType = typeof(Person);
            foreach (string item in args)
            {
                personType.GetProperty(item).SetMethod.Invoke(result, new object[] { true });
            }
            return result;
        }
    }
    public class Person
    {
        public bool Old { get; set; }
        public bool Educated { get; set; }
        public bool Employed { get; set; }
        public bool Married { get; set; }
    }
