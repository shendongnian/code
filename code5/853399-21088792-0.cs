    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApplication19
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string xml = @"<A><B  id='ABC'><C name='A' /><C name='B' /><C name='C' /><C name='G' /></B><B id='ZYZ'><C name='A' /><C name='B' /><C name='C' /><C name='D' /></B></A>";
                var doc = XDocument.Parse(xml);
    
                var bs = doc.Descendants("B");
    
                foreach (var r in bs)
                {
                    var cs = r.Descendants("C");
    
                    var xElements = cs as XElement[] ?? cs.ToArray();
                    for (var i = 1; i <= xElements.Count(); i++)
                    {
                        var c = xElements.ElementAt(i-1);
                        c.SetAttributeValue("Sno", i);
                    }
                }
    
                var resultingXml = doc.ToString();
            }
        }
    }
