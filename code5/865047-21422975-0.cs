    var element = XDocument.Load("filepath")
                           .Descendants("connectionStrings")
                           .FirstOrDefault();
    var connStrings = new Dictionary<string,string>();
    if(element != null)
    {
       foreach(var item in element.Elements("add"))
       {
          var name = (string)item.Attribute("name");
          var connString = (string)item.Attribute("connectionString");
          connStrings.Add(name,connString);
      }
    }
