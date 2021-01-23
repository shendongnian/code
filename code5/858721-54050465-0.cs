    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.Net.WebClient webclient = new System.Net.WebClient();
                string ip = webclient.DownloadString("http://whatismyip.org/");
                Regex reg = new Regex("((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)");
                if (reg.Match(ip).Success)
                {
                    Console.WriteLine(reg.Match(ip).ToString ());
                    Console.WriteLine("Success");
                }
            //    Console.Write (ip);
                Console.ReadLine();
            }
        }
    }
