    public class Program
    {
        private static void Main(string[] args)
        {
            var person = new Person {Name = "Test"};
            Console.WriteLine(person.Name);
    
            Person person2 = person;
            person2.Name = "Shahrooz";
            Console.WriteLine(person.Name);//Output:Shahrooz
            //person2 = null;
            Console.WriteLine(person.Name);//Output:Shahrooz
    
        }
    }
    public class Person
    {
        public string Name { get; set; }
    }
