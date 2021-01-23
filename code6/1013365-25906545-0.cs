    var xd = XDocument.Parse(xml);
     
    xd.Root.Elements("Service") // Enumerate the service elements
        .Where 
        (
            x=>
            (string)x.Element("TITLE") == "Collect Call and SMS"
        )                       // Find the ones you are interested in
        .Remove();              //Remove them from the document 
