    using System;
    using System.Net;
    class Program
    {
        static void Main()
        {
            string a = WebUtility.HtmlEncode("<html><head><title>T</title></head></html>");
            string b = WebUtility.HtmlDecode(a);
            Console.WriteLine("After HtmlEncode: " + a);
            Console.WriteLine("After HtmlDecode: " + b);
        }
    }
