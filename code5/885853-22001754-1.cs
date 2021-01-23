    public static string Serialize<T>(T t)
    {
    	var xmlser=new XmlSerializer(typeof(T));	
    	XmlWriterSettings settings = new XmlWriterSettings();
    
    	using(StringWriter textWriter = new StringWriter()) {
    		using(XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings)) {
    			xmlser.Serialize(xmlWriter, t);
    		}
    		return textWriter.ToString();
        }
    }
    
    public static T Deserialize<T>(string xml) 
    {
    	 if(string.IsNullOrEmpty(xml)) {
            return default(T);
        }
    
        XmlSerializer serializer = new XmlSerializer(typeof(T));
    	
    	XmlReaderSettings settings = new XmlReaderSettings();
    
        using(StringReader textReader = new StringReader(xml)) {
            using(XmlReader xmlReader = XmlReader.Create(textReader, settings)) {
                return (T) serializer.Deserialize(xmlReader);
            }
        }
    }
