    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.Collections.Generic;
    namespace StackOverflow
    {
        class Program
        {
            const string xml = "<SessionInfo><SID>68eba0c8cef752a7</SID><Challenge>37a5fe9f</Challenge><BlockTime>0</BlockTime><Rights><Name>Phone</Name><Access>2</Access><Name>Dial</Name><Access>2</Access><Name>HomeAuto</Name><Access>2</Access><Name>BoxAdmin</Name><Access>2</Access></Rights></SessionInfo>";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Parse(xml); //loads xml from string above rather than file - just to make it easy for me to knock up this sample for you
                string nameOfElementToFind = "Name";
                IEnumerable<XElement> matches = doc.XPathSelectElements(string.Format("//*[local-name()='{0}']",nameOfElementToFind));
                //at this stage you can reference any value from Matches by Index
                Console.WriteLine(matches.Count() > 2 ? "Third name is: " + matches.ElementAt(2).Value : "There less than 3 values");
                //or can loop through
                foreach (XElement match in matches)
                {
                    Console.WriteLine(match.Value);
                }
                Console.WriteLine("Done");
                Console.ReadKey();
            }
        }
    }
