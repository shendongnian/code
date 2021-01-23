using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Sockets;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Danish to English: ");
            string tittyfuck = Console.ReadLine();
            Console.Beep();
            <strong>WebRequest webRequest = WebRequest.Create("http://translate.google.com/#da/en/" + tittyfuck);</strong>
            WebResponse webResponse = webRequest.GetResponse();
            Stream data = webResponse.GetResponseStream();
            string html;
            using (StreamReader streamReader = new StreamReader(data))
            {
                string line;
                <strong>while ((line = streamReader.ReadLine()) != null)</strong>
                {
                    if (line == "&lt;span class=\"hps\"&gt;")
                    {
                        Console.Beep();
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
