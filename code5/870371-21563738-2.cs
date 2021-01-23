    var xdoc = XDocument.Load(path_to_xml);
    var student = xdoc.Root.Elements("Student")
                      .FirstOrDefault(s => (int)s.Element("id") == id);
    
    if (student != null) // check if student was found
    {
        var info = student.Element("information");
        if (info == null) // check if it has information element
        {
            info = new XElement("information");
            student.Add(info); // create and add information element
        }
        var lastValue = info.Elements("data")
                            .OrderBy(d => (DateTime)d.Attribute("DateTime"))
                            .Select(d => (int)d.Attribute("Value"))
                            .LastOrDefault(); // get latest value
        // create new data element
        var data = 
          new XElement("data", 
            new XAttribute("DateTime", DateTime.Now.ToString("MM.dd.yyyy HH:mm:ss")),
            new XAttribute("Value", lastValue == 0 ? 1 : 0));
        info.Add(data); // add data element to information element
        xdoc.Save(path_to_xml); // save file
    }
