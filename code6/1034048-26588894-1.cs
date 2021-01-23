    using System;
    using System.Net;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                WebRequest ftp =  FtpWebRequest.Create("ftp://ftp.ed.ac.uk/");
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                using (WebResponse rsp = ftp.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(rsp.GetResponseStream()))
                    {
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
        }
    }
