    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        var list = XDocument.Load(response.GetResponseStream())
            .Descendants("MyType")
            .Select(elem => new MyType
            {
                FirstName = elem.Element("firstName").Value,
                LastName = elem.Element("lastName").Value,
                City = elem.Element("city").Value
            }).ToList();
    }
