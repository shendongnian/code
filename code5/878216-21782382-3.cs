    using System;
    using System.Configuration;
    class Program
    {
        private static int clientID;
        private static string apiUrl;
        static void Main(string[] args)
        {
            // Try to get clientID - example that this is a required field
            if (!int.TryParse( ConfigurationManager.AppSettings["ClientID"], out clientID))
                throw new Exception("ClientID in appSettings missing or not an number");
    
            // Get apiUrl - example that this isn't a required field; you can
            // add string.IsNullOrEmpty() checking as needed
            apiUrl = ConfigurationManager.AppSettings["apiUrl"];
    
            Console.WriteLine(clientID);
            Console.WriteLine(apiUrl);
            Console.ReadKey();
        }
    }
