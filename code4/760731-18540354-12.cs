    public class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();
            Console.WriteLine("The max id is {0}", persons.MaxId(p => p.Id));
        }  
    }
