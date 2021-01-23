    using System;
    using System.Diagnostics;
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Thrower();
            }
            catch (Exception e)
            {
                var trace = new StackTrace(e);
                Console.WriteLine(trace.GetFrame(0).GetMethod());
            }              
        }
        
        private static string Thrower()
        {
            throw new Exception("Boom");
        }
    }
