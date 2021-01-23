    var settings = element.Elements("section")
         .ToDictionary(section => section.Attribute("name").Value,
                       section => section.Elements()
                           .ToDictionary(setting => setting.Attribute("name)".Value,
                                         setting => setting.Value));
    Console.WriteLine(settings["foo"]["sth1"]); // lala
        
