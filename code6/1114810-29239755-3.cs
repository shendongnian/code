        XmlDocument ToXmlDocument(CameraPropertyList list)
        {
            var doc = new XmlDocument();
            var rootNode = doc.CreateElement("Camera_Properties");
            doc.AppendChild(rootNode);
            foreach (var property in list.Properties)
            {
                var element = doc.CreateElement("Property");
                element.SetAttribute("Name", property.Name);
                element.SetAttribute("Value", property.Value);
                element.SetAttribute("Category", property.Category);
                element.SetAttribute("Type", property.Type);
                element.SetAttribute("Description", property.Description);
                rootNode.AppendChild(element);
            }
            return doc;
        }
