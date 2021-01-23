    internal class Program
    {
        private static void Main(string[] args)
        {
            var list_people = new List<Person> {
                  new Person() {Age = 4, Name = "yo"}, 
                  new Person() {Age = 5, Name = "a"}  
            };
            var dynamic_propretry = typeof (Person).GetProperty("Name");
            var sorted = list_people.OrderBy(person => dynamic_propretry.GetValue(person, null));
            
            foreach (var person in sorted)
            {
                Console.Out.WriteLine(person);
            }
            
            Console.ReadLine();
        }
    }
  
    public class Person{
 
     public int Age { get; set; }
     public string Name { get; set; }
        public override string ToString()
        {
            return Name + ":" + Age;
        }
    } 
