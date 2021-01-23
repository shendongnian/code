    public class Program
    {
        static void Main()
        {
            var person1 = new Person { Name = "Test" };
            Console.WriteLine(person1.Name);
    
            Person person2 = person1;
            person2.Name = "Shahrooz";
            Console.WriteLine(person1.Name);//Output:Test
            Console.WriteLine(person2.Name);//Output:Shahrooz
            person2 = new Person{Name = "Test2"};
            Console.WriteLine(person2.Name);//Output:Test2
    
        }
    }
    public struct Person
    {
        public string Name { get; set; }
    }
