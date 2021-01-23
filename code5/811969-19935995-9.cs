    public static void WriteXmlWithCurrentDate(this DataSet ds, string fileName)
    {
        // Create the MemoryStream to write with. 
        using (MemoryStream stream = new MemoryStream())
        {
            // Write to stream with the WriteXml method.
            ds.WriteXml(stream);
            // Reset stream to origin
            stream.Seek(0, SeekOrigin.Begin);
            // Load stream as XDocument
            XDocument xdoc = XDocument.Load(stream);
            // get current date as string
            string today = DateTime.Today.ToString("d", new CultureInfo("ru-RU"));
            // Set date attribute on root element
            xdoc.Root.SetAttributeValue("Date", today);
            // Save to file as XML
            xdoc.Save(fileName);
        }
    }
