    using System;
    
    class Example
    {
        public Example()
        {
    	Console.WriteLine("Constructor");
        }
    
        ~Example()
        {
    	Console.WriteLine("Destructor");
        }
    }
    
    class Program
    {
        static void Main()
        {
    	Example x = new Example();
        }
    }
