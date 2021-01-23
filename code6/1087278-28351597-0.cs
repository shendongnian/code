    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace XmlCompare
    {
        using System.IO;
        using System.Xml.Linq;
        using System.Xml.XPath;
    
        class Program
        {
    
            private static string xml1 = "<Surtaxe>" + "<Zone CodeZoneSurtaxe=\"2\" NbPlisZone=\"0\" PoidsZone=\"0\" />"
                                         + "<Zone CodeZoneSurtaxe=\"1\" NbPlisZone=\"1\" PoidsZone=\"1\" />" + "</Surtaxe>";
    
            private static string xml2 = "<Surtaxe>" + "<Zone CodeZoneSurtaxe=\"1\" NbPlisZone=\"1\" PoidsZone=\"1\" />"
                                         + "<Zone CodeZoneSurtaxe=\"2\" NbPlisZone=\"0\" PoidsZone=\"0\" />" + "</Surtaxe>";
    
            private static void Main(string[] args)
            {
             
                var expectedDoc = XDocument.Load(new StringReader(xml1));
                var testedDoc = XDocument.Load(new StringReader(xml2));
                var success = true;
    
                //naive
                foreach (var node in expectedDoc.Descendants("Surtaxe").First().Descendants())
                {
                    if (testedDoc.Descendants(node.Name).FirstOrDefault(x => x.ToString()== node.ToString()) == null)
                    {
                        success = false;
                        break;
                    }
                }
    
                //sort
                var sortedExpected = xml1.ToList();
                sortedExpected.Sort();
    
                var testSorted = xml2.ToList();
                testSorted.Sort();
    
                success = new string(sortedExpected.ToArray()).Equals(new string(testSorted.ToArray()));
    
                Console.WriteLine("Match? " + success);
                Console.ReadKey();
    
            }
        }
    }
