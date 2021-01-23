    using System;
    using System.Globalization;
    using System.Xml;
    
    namespace ConsoleApplication9
    {
        class Program
        {
            private static void Main(string[] args)
            {
                //Valid XML
                string xml = @"<Envelope xsd='http'>
                              <Catalog>
                                 <Price>
                                   <Value Default='yes'>P1</Value>
                                </Price>
                              </Catalog>
                             </Envelope>";
                var doc = new XmlDocument();
                doc.LoadXml(xml);
    
                //Select the Value Node
                XmlNode node = doc.SelectSingleNode("/*/Catalog/Price/Value");
    
                //Set the Default attribute to 1
                node.Attributes["Default"].Value = 1.ToString(CultureInfo.InvariantCulture);
    
                //Check the output
                Console.WriteLine(doc.InnerXml.ToString(CultureInfo.InvariantCulture));
    
                //Press enter to exit
                Console.ReadLine();
            }
        }
    }
