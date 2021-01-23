    using System;
    using System.IO;
    using System.Net;
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest wr = WebRequest.Create("http://www.google.com");
            WebProxy proxy = new WebProxy("http://localhost:8888");
            wr.Proxy = proxy;
            StreamReader sr = new StreamReader(wr.GetResponse().GetResponseStream());
            Console.WriteLine(sr.ReadToEnd());
            Console.ReadLine();
        }
    }
