    using System;
    #region Write to Console
    /*2 ways to write to console
     concatenation
     place holder syntax - most preferred
     Please note that C# is case sensitive language.
    */
    #region
    namespace _2__CShrp_Read_and_Write
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                // Prompt the user for his name
                Console.WriteLine("Please enter your name");
    
                // Read the name from console
                string UserName = Console.ReadLine();
                // Concatenate name with hello word and print
                //Console.WriteLine("Hello " + UserName);
    
                //place holder syntax
                //what goes in the place holder{0}
                //what ever you pass after the comma i.e. UserName
                Console.WriteLine("Hello {0}", UserName);
                Console.ReadLine();
            }
        }
    }
    I hope this helps
