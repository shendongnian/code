    using System;
    using System.Net;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            string text;
            using (var webClient = new WebClient())
            {
                string url = "http://scotjobsnet.co.uk.ni.strategiesuk.net/testfeed.xml";
                webClient.Headers.Add("user-agent", "Mozilla/5.0");
                text = webClient.DownloadString(url);
            }
            var doc = XDocument.Parse(text);
            foreach (var job in doc.Root.Elements("job"))
            {
                Console.WriteLine(job);
            }
        }
    }
