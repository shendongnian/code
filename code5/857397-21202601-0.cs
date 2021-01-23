    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var doc = XDocument.Load("test.xml");
            XNamespace ns = "http://somestuff.new/ns3";
            var gauges = doc
                .Descendants(ns + "Gauges")
                .Select(x => new { // You'd use new Gauge here
                    Speed = (double?) x.Element(ns + "Speed") ?? 0.0,
                    Rpm = (int?) x.Element(ns + "Rpm") ?? 0
                });
            foreach (var gauge in gauges)
            {
                Console.WriteLine(gauge);
            }
        }
    }
