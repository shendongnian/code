    string input = "<Your xml>";
    
    Xdocument doc = XDocument.Parse(input);
    
    var data = doc.Descendants("item");
    List<Items> itemsList = new List<Items>();
    
    foreach(var item in data)
    {
    string itemname= item.Element("item").Value;
    string property = item.Element("property").Value;
    itemsList.Add(new item(itemname, property));
    }
