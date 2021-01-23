    var query = from p in Process.GetProcesses()
                orderby p.ProcessName
                select p;
    
    List<XElement> content = new List<XElement>();
    foreach (var item in query)
    {
        content.Add(new XElement("Process",
            new XAttribute("Name", item.ProcessName),
            new XAttribute("PID", item.Id)));
    }
    
    var paramArr = content.ToArray();
    var rootElement = new XElement("Processes", paramArr); // create one root element
    XDocument doc = new XDocument(rootElement);
