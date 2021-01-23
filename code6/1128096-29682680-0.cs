    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace testApp_1
    {
        class Program
        {
            static void Main(string[] args)
            {
                String word = "Hello world!";
    
                Console.WriteLine(word);
                
                //if you want the user to exit with any key press do this
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                //if you want the user to hit 'enter' to exit do this
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
        }
    }
    
