    public class Unit
    {
        public string Name { get; set; }
    	
        public string ID { get; set; }
    }
    public class Produced_by : IXmlSerializable
    {
        public Unit Unit { get; set; }
    	
    	public void WriteXml (XmlWriter writer)
        {
    		writer.WriteStartElement("Produced_by");
            writer.WriteStartElement("Producing_Unit");
    		writer.WriteStartElement("Unit");
    		writer.WriteAttributeString("ID", this.Unit.ID);
    		writer.WriteAttributeString("Name", this.Unit.Name);
    		writer.WriteEndElement();
    		writer.WriteEndElement();
    		writer.WriteEndElement();
        }
    
        public void ReadXml (XmlReader reader)
        {
    		while (reader.Read())
    		{
    			if (reader.Name == "Unit")
    			{
    				this.Unit = new Unit()
    				{
    					Name = reader.GetAttribute("Name"),
    					ID = reader.GetAttribute("ID")
    				};
    				
    				break;
    			}
    		}
        }
    	
    	public XmlSchema GetSchema()
        {
            return(null);
        }
    }
