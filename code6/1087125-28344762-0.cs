        public string Save()
		{
			XmlSerializer serializer = new XmlSerializer(this.GetType());
    		using(StringWriter writer = new StringWriter())
    		{
    		   serializer.Serialize(writer, this);
    		   return writer.ToString();
		    }
		}
