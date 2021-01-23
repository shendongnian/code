    [Extension()]
    public void WriteXmlWithCurrentDate(DataSet ds, string fileName)
    {
    	// Create the FileStream to write with. 
    	FileStream stream = new FileStream("XmlDoc.xml", FileMode.Create);
    	// Write to stream with the WriteXml method.
    	ds.WriteXml(stream);
    	// Reset stream to origin
    	stream.Seek(0, System.IO.SeekOrigin.Begin);
    	// Load stream as XDocument
    	XDocument xdoc = XDocument.Load(stream);
    	// Set date attribute on root element
    	xdoc.Root.SetAttributeValue("Date", DateAndTime.Today.ToString("MM.dd.yyyy"));
    	// Save to XML to file
    	xdoc.Save(fileName);
    }
