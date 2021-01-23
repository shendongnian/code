     public void ReadXml(XmlReader reader)
     {
        reader.MoveToContent();
        var empty=reader.IsEmptyElement;
        reader.ReadStartElement();
        if(!empty){
            Details1=reader.ReadElementString("Details1");
            reader.ReadEndElement();
        }
    }
    public void WriteXml(XmlWriter writer)
    {
        var str=string.IsNullOrWhiteSpace(Details1)?"":Details1;    	    
        writer.WriteElementString("Details1",str);
    }
