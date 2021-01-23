    var xdoc = XDocument.Load(path);
    var customer = from node in xdoc.Descendants("customer")
    select new
    {
        FirstName = node.Element("FirstName").Value.ToString(),
        LastName = node.Element("LastName").Value.ToString(),
        Email = node.Element("Email").Value.ToString(),
        foreach (var item in customer)
        {
            var test = item.FirstName;
            Console.WriteLine(test);
        }
