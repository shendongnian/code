     XDocument xmlDoc = XDocument.Load("XMLFile1.xml");
                XElement root = new XElement("Batch");
    
                root.Add(new XAttribute("ID", 1));
                root.Add(new XAttribute("Date", 2));
                root.Add(new XElement("Step"));
                root.Add(new XAttribute("Name", 3));
                root.Add(new XAttribute("Success", 4));
                root.Add(new XAttribute("Message", 5));
                root.Add(new XElement("Transaction"));
                root.Add(new XAttribute("Details", 7));
    
                xmlDoc.Root.Add(root);
                xmlDoc.Save("c:\\try.xml");
