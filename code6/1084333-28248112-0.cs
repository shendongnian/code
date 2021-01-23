    using System;
    using System.Net;
    
    public class Program
    {
        public static void Main()
        {
            string b = WebUtility.HtmlDecode("Quelque petite scratch sur l&#233;cran");
    
            Console.WriteLine("After HtmlDecode: " + b);
    
        }
    }
