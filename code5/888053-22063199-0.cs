    var xDoc = XDocument.Parse(...);
    var elementToUpdate = xDoc.Root
                              .Descendants("Compliance_Item")
                              .Single(ci => ci.Element("Application_Name").Value == "Notepad++")
                              .Element("Used_Deferrals");
    elementToUpdate.Value = (Int32.Parse(elementToUpdate.Value) + 1).ToString();
