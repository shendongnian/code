    public XmlSchema GetSchema()
    {
        return null; //this should remain equal
    }
    
    public void ReadXml(XmlReader reader)
    {
       throw new NotImplementedException();
    }
    
    public void WriteXml(XmlWriter writer)
    {
        //group your list of Person as you want then
        foreach (Person person in list)
        {
            writer.WriteStartElement("Persons");
            person.WriteXml(writer);
            writer.WriteEndElement();
        }
    }
