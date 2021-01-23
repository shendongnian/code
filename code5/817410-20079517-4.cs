    List<ObjectToHoldValues> MasterObject = new List<ObjectToHoldValues>();
            using (TextReader reader = new StreamReader(sourceXmlFileName, Encoding.UTF8))
            {
                // Create an xml document and assign it to a local variable
                XDocument doc = XDocument.Load(reader);
                // Load the roots
                foreach (XElement element in doc.Descendants("root"))
                {
                    ObjectToHoldValues itemList = new ObjectToHoldValues();
                    itemList = callAboveExample(element);
                    
                    MasterObject.Add(itemList);
                }
            }
