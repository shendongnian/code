    using System;
    using System.IO;
    using System.Net;
    class Program
    {
        static void Main(string[] args)
        {
            WebProxy proxy = new WebProxy("http://localhost:8888");
            GlobalProxySelection.Select = proxy;
            WebRequest wr = WebRequest.Create("http://www.google.com");
            
            StreamReader sr = new StreamReader(wr.GetResponse().GetResponseStream());
            Console.WriteLine(sr.ReadToEnd());
            Console.ReadLine();
        }
    }
