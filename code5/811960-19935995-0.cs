    DataSet das = new DataSet();
    das.DataSetName = "Stock";
    das.Tables.Add(new DataTable("Assortment"));
    das.Tables[0].Columns.Add("Item", typeof(string));
    das.Tables[0].Columns.Add("Quantity", typeof(Int16));
    das.Tables[0].Rows.Add("Sock", 1);
    das.Tables[0].Rows.Add("Puppet", 2);
    
    // Create the FileStream to write with. 
    System.IO.FileStream stream = _
        new System.IO.FileStream("XmlDoc.xml", System.IO.FileMode.Create);
    
    // Write to stream with the WriteXml method.
    das.WriteXml(stream);
    
    // Reset stream to origin
    stream.Seek(0, System.IO.SeekOrigin.Begin);
    
    // Load stream as XDocument
    XDocument xdoc = XDocument.Load(stream);
    
    // Set date attribute on root element
    xdoc.Root.SetAttributeValue("Date", DateAndTime.Today.ToString("MM.dd.yyyy"));
    
    // Save to XML to file
    xdoc.Save("c:\\temp\\xml.xml");
