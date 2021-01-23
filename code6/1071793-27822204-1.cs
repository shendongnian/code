        var oldentity = Deserialize<T>(oldXml,
            new SerializerTypeSurrogate());
        var newXml = FormalizedChangeRecord.Serialize<T>(card);
    public static TCard Deserialize<T>(string xmlData, IDataContractSurrogate surrogate)    		{
                var serializer = new DataContractSerializer(typeof (T), new Type[0], 10000, true, true, surrogate);
    		using (var stringReader = new StringReader(changeRecord.CardData))
    		{
    			using (var xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings { CloseInput = false }))
    			{
    				var entity= (TCard)serializer.ReadObject(xmlReader);
    				return entity;
    			}
    		}
    	}
    public static string Serialize<T>(T entity)
    	{
    	    var serializer = new DataContractSerializer(typeof (T));
    			using (var stringWriter = new StringWriter())
    			{
    				using (
    					var xmlWriter = XmlWriter.Create(stringWriter,
    	                    new XmlWriterSettings
    				{
    	                        CloseOutput = false,
    	                        Encoding = new UTF8Encoding(false),
    	                        OmitXmlDeclaration = true,
    	                        Indent = true
    	                    }))
    	            {
    					serializer.WriteObject(xmlWriter, entity);
    				}
    	            return stringWriter.ToString();
    			}
    		}
