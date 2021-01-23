    var Result = from a in element.Descendants("Page")
                 from b in a.Descendants("Type")
                 select new
                 {
                   Page = a.Attribute("Name").Value,
                   Type = b.Attribute("TypeID").Value,
                   Fields = String.Join(",", b.Elements("Field").Select(x => x.Value))
                 };
    foreach (var item in Result)
    {
      Console.WriteLine(String.Format("Page = {0}:Type={1}:Fields:{2}", item.Page, item.Type, item.Fields));
    }
