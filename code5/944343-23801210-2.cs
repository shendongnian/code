    var xdoc = XDocument.Load(path_to_xml);
    Regex regex = new Regex(@"Line (?<line>\d+) for stock code '(?<code>\w+)'");
    var orders = from o in xdoc.Root.Elements("Order")
                 select new
                 {
                     SalesOrder = (string)o.Element("SalesOrder"),
                     WarningMessages =
                         from m in o.Element("WarningMessages").Elements()
                         let match = regex.Match((string)m)
                         where match.Success
                         select new
                         {
                             Line = match.Groups["line"].Value,
                             Code = match.Groups["code"].Value
                         }
                 };
