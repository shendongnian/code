    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    namespace ConsoleApplication9
    {
    class Program
    {
        static void Main(string[] args)
        {
            string hostName = "google.com";
            Console.WriteLine(hostName);
            string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            Console.WriteLine("My IP Address is: {0}", myIP);
            Console.ReadLine();
            Console.WriteLine("Updating Host file");
            string newIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            Console.WriteLine("My IP Address is: {0}", newIP);
            Console.ReadLine();
        }
    }
    }
