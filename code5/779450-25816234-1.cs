    using System;
    using System.Xml;
    using System.Xml.Linq;
    
    public class CDataExample
    {
        public static void Main()
        {
            string documentXml = "<doc><content></content></doc>";
            XElement doc = XElement.Parse(documentXml, LoadOptions.None);
    
            string userInput =
     @"<bk:book>
       <title>Pride And Prejudice</title>
       <authorlastname>Jane</authorlastname>
       <authorfirstname>Austen</authorfirstname>
       <price>24.95</price>
     </bk:book>";
    
            XCData cdata = new XCData(userInput);
            doc.Element("content").Add(cdata);
    
            Console.WriteLine(doc.ToString());
        }
    }
