    class Program
    {
        public abstract class BasePerson
        {
            public string FirstName { get; set; }
        }
        public class Person : BasePerson
        {
        }
        public class Client : BasePerson
        {
            public string LastName { get; set; }
            public static implicit operator Client(Person p)
            {
                if (p == null)
                {
                    return null;
                }
                return new Client { FirstName = p.FirstName };
            }
        }
        static void Main(string[] args)
        {
            Person p = new Person { FirstName = "Test" };
            Client c = (Client)p;
            Console.WriteLine(c.FirstName);
            Console.ReadLine();
        }
    }
