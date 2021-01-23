    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
            Console.Write("what is your age?");
            string agestring = Console.ReadLine();
            int age;
            if (Int32.TryParse(agestring, out age))
            {
				if (age >= 21)
				{
					Console.WriteLine("congrats, you're you can get drunk!");
				}
				else if (age < 21)
				{
					Console.WriteLine("Sorrrrrryyyyyyy =(");
				}
            }
			else
			{
				Console.WriteLine("Sorry Thats not a valid input");
			}
            
        }
    }
