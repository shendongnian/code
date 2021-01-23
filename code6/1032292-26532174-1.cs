    var xdoc = XDocument.Parse(xmlFileName); // using System.Xml.Linq;
    var interestingGroupingSections = xdoc
             .XPathSelectElements("//Chart[@ce='p']/GroupingSection"); // using System.Xml.XPath;
    if (interestingGroupingSections.Any())
    {
        firstValue = Convert.ToInt32(interestingGroupingSections.First()
           .Attributes("count")
           .First().Value);
        secondValue = Convert.ToInt32(interestingGroupingSections.Skip(1)
           .Attributes("count")
           .First().Value);
    }
