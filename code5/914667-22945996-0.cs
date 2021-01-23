    foreach (WorldObject wO in list)
            {
                 writer.WriteStartElement(wO.GetType().ToString());
    
                 wO.WriteXml(writer);
    
                 writer.WriteEndElement();
            }
