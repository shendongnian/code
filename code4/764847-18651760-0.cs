     //Load the current xml
            var Document = new XDocument();
            Document = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"MyXmlFile.xml");
            //Get the Superitem based on id attribute (you'll want to do some checks to make sure that the xml has the relevent <superitem> node
            XElement superitem = Document.Root.Element("superitem").Elements().FirstOrDefault(x => (int?)x.Attribute("id") == 10);
            //check a superitem with the id was found
            if (superitem != null)
            {
                //Create New Document:
                var newDocument = new XDocument();
                newDocument.Declaration =
                    new XDeclaration("1.0", "utf-8", null);
                //Create Root node (items)
                XElement root = new XElement("items");
                newDocument.Add(root);
                //Add the super item to the root.
                root.Add(new XElement("superitem", superitem));
                //Save
                newDocument.Save(AppDomain.CurrentDomain.BaseDirectory + @"SuperItem.xml");
            }
