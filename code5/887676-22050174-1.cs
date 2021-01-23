    var xDoc = XDocument.Load("path");
    var count = xDoc.Descendants("user").Count();
    var newUser = new XElement("user",
                      new XElement("id", count+1),
                      new XElement("name", nameBox.Text),
                      new XElement("surname", surnameBox.Text),
                      new XElement("weight", weightUpDown.Value),
                      new XElement("height", heightUpDown.Value));
    xDoc.Root.Add(newUser);
    xDoc.Save(path);
