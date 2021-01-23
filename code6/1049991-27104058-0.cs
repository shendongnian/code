    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = XDocument.Parse(xml);
            XElement history = xdoc.Element("relationshipHistory");
            IEnumerable<XElement> histories = history.Elements();
            IEnumerable<XElement> historiesSorted = 
                histories
                .OrderBy(x => int.Parse(x.Attribute("code").Value))
                .Select(x => new XElement(x))
                .ToList();
            history.RemoveAll();
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
