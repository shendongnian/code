	public void Print(string xmlFile)
	{
		if (String.IsNullOrWhiteSpace(xmlFile))
			throw new ArgumentNullException("No xml file has been passed to the Print method.");
		// This line will most likely throw an exception if the XMl file is not well formated
		XDocument dom = XDocument.Load(xmlFile);
		foreach (XElement n in dom.XPathSelectElements("//RECORDS/RECORD"))
		{
			try
			{
				// send commands to the printer, if the printer fails to print, throw a PrinterRecordException
			}
			catch (PrinterRecordException e)
			{
				// log print failure, but keep on printing the rest
				continue;
			}
			catch (Exception e)
			{
				// dunno what happened, but still have to print the rest
				continue;
			}
		}
	}
