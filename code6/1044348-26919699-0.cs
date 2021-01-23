    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    class Program
    {
        static void Main()
        {
            var notNeededBarNames = new[] {1, 3};
            var elems = new[] {"Bars1", "Bars2", "Gubbins3"};
            var newXDoc = new XElement("root");
            var xDoc = XDocument.Load("PathToYourXmlFile");
            foreach (var elem in elems)
            {
                newXDoc.Add(new XElement(elem));
                var curElem = newXDoc.Elements(elem).Single();
                string xpath = String.Format("root/{0}/Bar", elem);
                var childElems = xDoc.XPathSelectElements(xpath);
                foreach (var childElem in childElems)
                {
                    bool add = true;
                    var nameAtt = childElem.Attribute("name");
                    if (nameAtt != null)
                    {
                        int val = Convert.ToInt32(nameAtt.Value);
                        if (notNeededBarNames.Any(x => x == val))
                        {
                            add = false;
                        }
                    }
                    if (add)
                    {
                        curElem.Add(childElem);   
                    }
                }
            }
            var newXml = newXDoc.ToString();
        }
    }
