    var xDoc = XDocument.Load(fname);
    HashSet<string> set = new HashSet<string>(xDoc.Root.Element("groups")
                                                  .Descendants("dn")
                                                  .Select(dn => (string)dn));
    foreach (var user in xDoc.Root.Element("users").Elements("user").ToList())
    {
        if(!set.Contains(user.Element("dn").Value))
            user.Remove();
    }
    var newXml = xDoc.ToString();
