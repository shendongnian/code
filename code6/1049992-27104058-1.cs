    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = XDocument.Parse(xml);
            XElement history = xdoc.Element("relationshipHistory");
            IEnumerable<XElement> histories = history.Elements();
            // Sort elements and create new elements because the RemoveAll method will delete the old ones.
            IEnumerable<XElement> historiesSorted = 
                histories
                .OrderBy(x => int.Parse(x.Attribute("code").Value))
                .Select(x => new XElement(x))
                .ToList();
            // Remove the old elements.
            history.RemoveAll();
            // Add the sorted elements to the parent element.
            foreach (var item in historiesSorted)
            {
                history.Add(item);
            }
        }
    
        static string xml = @"<?xml version='1.0' encoding='UTF-8\'?>
            <relationshipHistory>
                <relationship code='204'>
                    <from>2014-09-09</from>
                </relationship>
                <relationship code='201'>
                    <to>2014-09-08</to>
                </relationship>
            </relationshipHistory>";
    }
