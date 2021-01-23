    using System;
    using System.Configuration;
    class Program
    {
        private static int clientID;
        static void Main(string[] args)
        {
            int.TryParse( ConfigurationManager.AppSettings["ClientID"], out clientID);
            Console.WriteLine(clientID);
            Console.ReadKey();
        }
    }
