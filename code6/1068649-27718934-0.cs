    using System;
    using System.Threading;
    
    class Program
    {
        static void Main(string[] args)
        {
            string text = "This will be printed one character at a time";
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
        }
    }
