    List<string> items = new List<string>();
    XmlDocument xmlDOC = new XmlDocument();
    xmlDOC.Load(@"E:\Delete Me\ConsoleApplication1\ConsoleApplication1\bin\Debug\List.xml");
    var elements = xmlDOC.GetElementsByTagName("value");
    foreach (var item in elements)
    {
       XmlElement value = (XmlElement)item;
       items.Add(string.Format("{0}:{1}", value.GetAttribute("periodid"), value.GetAttribute("value")));
    }
   
