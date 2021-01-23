    Lists list = new Lists(); //SharePoint Lists SOAP service
          
    //Perform request
    XmlNode result = list.GetListCollection();
           
    var docResult = XDocument.Parse(result.OuterXml);
    XNamespace s = "http://schemas.microsoft.com/sharepoint/soap/";
    var listEntries = from le in docResult.Descendants(s + "List")
                              select new
                                  {
                                      Title = le.Attribute("Title").Value
                                  };
    foreach (var e in listEntries)
    {
         Console.WriteLine(e.Title);
    }
