    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Checker
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program re = new Program();
                re.next();
                Properties.Settings.Default.Save();
            }
            public void next()
            {
                String name = Settings.Default.name;
                if (String.IsNullOrEmpty(name))
                {
                    Console.WriteLine("What is your name?");
                    name = Console.ReadLine();
                    Settings.Default.name = name;
                    Console.WriteLine("Thank you!");
                    Console.ReadKey();
                }
                else
                {                    
                    Console.WriteLine("Your name is " + name);
                }
            }
        }
    }
