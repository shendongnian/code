    StringBuilder output = new StringBuilder();
    
    using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
    {
        bool seenParam = false;
    
        XmlWriterSettings ws = new XmlWriterSettings();
        ws.Indent = true;
        using (XmlWriter writer = XmlWriter.Create(output, ws))
        {
            // Parse the file and write each of the nodes.
            while (reader.Read())
            {
                // Did we've seen the a node named parameters?
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "parameters")
                    seenParam = !seenParam;
                // If not, proceed with the next node
                if (!seenParam)
                    continue;
    
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        writer.WriteStartElement(reader.Name);
                        writer.WriteAttributes(reader, false);
                        break;
                    case XmlNodeType.Text:
                        writer.WriteString(reader.Value);
                        break;
                    case XmlNodeType.XmlDeclaration:
                    case XmlNodeType.ProcessingInstruction:
                        writer.WriteProcessingInstruction(reader.Name, reader.Value);
                        break;
                    case XmlNodeType.Comment:
                        writer.WriteComment(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        writer.WriteFullEndElement();
                        break;
                }
            }
        }
    }
