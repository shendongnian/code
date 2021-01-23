    var xDoc = XElement.Load("FilePath");
    if (xDoc == null)
       return;
    
    var myNewElement = new XElement("ElementName"
       new XAttribute("AttributeName", value1),
       new XAttribute("AttributeName", value2)
       //And so on ...
    );
    xDoc.Add(myNewElement);
    xDoc.Save("FilePath");
//
    doc.Root.Descendants(actualNode.Parent.Name)
            .Elements(actualNode.Name)
            .Remove();
