    public static T DeserializeXmlFromStream<T>(System.IO.Stream strm)
    {
    	System.Xml.Serialization.XmlSerializer deserializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
    	T ThisType = default(T);
    
    
        
    	using (System.IO.StreamReader srEncodingReader = new System.IO.StreamReader(strm, System.Text.Encoding.UTF8)) 
        {
            // ThisType = (T)deserializer.Deserialize(srEncodingReader);
            
            using (NamespaceIgnorantXmlTextReader SpecialNamespaceReaderBecauseMicrosoftSucks = new NamespaceIgnorantXmlTextReader(srEncodingReader))
            {
                ThisType = (T)deserializer.Deserialize(SpecialNamespaceReaderBecauseMicrosoftSucks);
                SpecialNamespaceReaderBecauseMicrosoftSucks.Close();
            } // End Using SpecialNamespaceReaderBecauseMicrosoftSucks
             
    		srEncodingReader.Close();
        } // End Using srEncodingReader
    
    	deserializer = null;
    
    	return ThisType;
    } // End Function DeserializeXmlFromStream
