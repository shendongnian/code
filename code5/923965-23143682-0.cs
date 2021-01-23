    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3348
    {
        class Program
        {
            class Person
            {
                string Name = "";
            }
    
            static void Main(string[] args)
            {
    
                Console.WriteLine("Assigning List to value");
                dynamic value = new List<Person>();
    
                if (value is List<Person>)
                {
                    Console.WriteLine("value is a list");
                }
    
                value = false;
    
                Console.WriteLine("Assigning bool to value");
                if (value is Boolean)
                {
                    Console.WriteLine("value is bool");
                }
    
                Console.Read();
            }
        }
    }
