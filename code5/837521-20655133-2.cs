    private void CreateXml()
    {
    	string xmlStr = "<RootNode></RootNode>";
    	XDocument document = XDocument.Parse(xmlStr);
    	XElement ex = new XElement(new XElement("FirstNOde"));
    	XElement ex1 = new XElement(new XElement("second"));
    	ex1.Value = "fdfgf";
    	ex.Add(ex1);
    	document.Root.Add(new XElement("ChildNode", "World!"));
    	document.Root.Add(new XElement("ChildNode", "World!"));
    	document.Root.Add(ex);
    	string newXmlStr = document.ToString();           
    }
    
    
    public void ReadXml()
    {
    	IsolatedStorageFileStream isoFileStream = myIsolatedStorage.OpenFile("Your xml file name", FileMode.Open);
    	
    	using (XmlReader reader = XmlReader.Create(isoFileStream))
    	{
    		XDocument xml = XDocument.Load(reader);
    		XElement root1 = xml.Root;
        }
    }
