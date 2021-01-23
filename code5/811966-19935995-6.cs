    [Extension()]
    public void WriteXmlWithCurrentDate(DataSet ds, string fileName)
    {
    	// Create the MemoryStream to write with. 
    	MemoryStream stream = new MemoryStream;
    	// Write to stream with the WriteXml method.
    	ds.WriteXml(stream);
    	// Reset stream to origin
    	stream.Seek(0, System.IO.SeekOrigin.Begin);
    	// Load stream as XDocument
    	XDocument xdoc = XDocument.Load(stream);
    	// Set date attribute on root element
    	xdoc.Root.SetAttributeValue("Date", DateAndTime.Today.ToString("MM.dd.yyyy"));
    	// Save to file as XML
    	xdoc.Save(fileName);
    }
