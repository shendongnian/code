    public class Program
    {
        private static void Main(string[] args)
        {
            var person = new Person {Name = "Test"};
            Console.WriteLine(person.Name);
    
            Person person2 = person;
            person2.Name = "Shahrooz";
            Console.WriteLine(person.Name);//Output:Shahrooz
            // Here you are just erasing a copy to reference not the object created.
            // Single memory allocation in case of reference type and  parameter
             // are passed as a copy of reference type .   
            person2 = null;
            Console.WriteLine(person.Name);//Output:Shahrooz
    
        }
    }
    public class Person
    {
        public string Name { get; set; }
    }
