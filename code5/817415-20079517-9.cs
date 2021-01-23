    public void LoadFromFile(string sourcXmlFileName = null)
    {
        // Checks to see if file has been specified, if not assign it to the default value
        if (string.IsNullOrEmpty(sourceXmdlFileName))
            sourceXmdlFileName = DefaultInventoryFile;
        // Check to make sure the file is there
            if (!File.Exists(sourceXmdlFileName))
                return;
        List<ObjectToHoldValues> MasterObject = new List<ObjectToHoldValues>();
    
                using (TextReader reader = new StreamReader(sourceXmlFileName, Encoding.UTF8))
                {
                    // Create an xml document and assign it to a local variable
                    XDocument doc = XDocument.Load(reader);
    
                    // Load the roots
                    foreach (XElement element in doc.Descendants("root"))
                    {
                        ObjectToHoldValues itemList = new ObjectToHoldValues();
                        itemList = LoadIndividualItem(element);
                        
                        MasterObject.Add(itemList);
                    }
                }
    }
