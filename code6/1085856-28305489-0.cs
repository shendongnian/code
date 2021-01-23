    using System;
    using System.Collections.Generic;
    using System.Net;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.example.com");
                request.Method = "POST";
                request.ContentType = "image/png";
                Console.WriteLine(GetRequestAsString(request));
                Console.ReadKey();
            }
            public static string GetRequestAsString(HttpWebRequest request)
            {
                string str = request.Method + " " + request.RequestUri + " HTTP/" + request.ProtocolVersion + Environment.NewLine;
                string[] headerKeys = request.Headers.AllKeys;
                foreach (string key in headerKeys)
                {
                    str += key + ":" + request.Headers[key];
                }
                return str;
            }
        }
    }
