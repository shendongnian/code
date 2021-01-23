    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("XMLFile1.xml");
            IEnumerable<XElement> reportElements = doc.Descendants("Report");
            IEnumerable<Report> reports = reportElements
                .Select(e => new Report
                {
                    Name = e.Attribute("Name").Value,
                    Input = new Input
                    {
                        Content = string.Join("\n", e.Element("Input").Element("Content").Elements().Select(c => c.ToString()))
                    }
                });
        }
    }
