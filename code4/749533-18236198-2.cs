    public class Program
    {
        private static void Main(string[] args)
        {
            var person1 = new Person { Name = "Test" };
            Console.WriteLine(person1.Name);
    
            PersonNullifier.NullifyPerson(ref person1);
            Console.WriteLine(person1); //Output: null
        }
    }
    
    
    class PersonNullifier
    {
        public static void NullifyPerson( ref Person p ) {
            p = null;
        }
    }
    
    class  Person {
        public string Name{get;set;}
    }
