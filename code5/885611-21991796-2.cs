    var selectedName = comboBox1.SelectedItem.ToString();
    var xDoc = XDocument.Load("path");
    var cust = xDoc.Descendants("PrivateCustomer")
               .FirstOrDefault(x => (string)x.Element("Name") == selectedName);
    if(cust != null)
    {
       // edit Customer
       cust.Element("Contract").Value = "some value..";
    }
    xDoc.Save("path");  // save the xml file
    
