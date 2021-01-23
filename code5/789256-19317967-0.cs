    using System;
    using System.Text;
    
    namespace homework1
    {
        class Program
        { 
            static int Main()
            {
                string firstName = Console.ReadLine();
                string surName = Console.ReadLine();
                string lastName = Console.ReadLine();
     
                Console.WriteLine("Hello, " + firstName + "!");
    
                Console.WriteLine("Your full name is " + 
                    String.Format("{0} {1} {2}"), firstName, surName , lastName ) + ".");
                return 0;
            }
        }
    }
