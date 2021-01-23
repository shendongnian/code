    using System;
	namespace ConsoleApplication1
	{
	    class Program
	    {
	        static void Main(string[] args)
	        {
	            string inputString = "Welcome !!!";
	            foreach(char input in inputString)
	            {
	                if(Char.IsLower(input))
	                    Console.WriteLine(input + " is a Lower Case Character");
	                else if (Char.IsUpper(input))
	                    Console.WriteLine(input + " is a upper Case Character");
	 
	            }
	 
	            Console.Read();
	        }
	    }
	}
