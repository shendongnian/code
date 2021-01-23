    /// <summary>
    /// Serialize an object into an XML string
    /// </summary>
    /// <typeparam name="T">Type of object to serialize.</typeparam>
    /// <param name="obj">Object to serialize.</param>
    /// <param name="enc">Encoding of the serialized output.</param>
    /// <returns>Serialized (xml) object.</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
    internal static String SerializeObject<T>(T obj, Encoding enc)
    {
    	using (MemoryStream ms = new MemoryStream())
    	{
    		XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings()
    		{
    			// If set to true XmlWriter would close MemoryStream automatically and using would then do double dispose
    			// Code analysis does not understand that. That's why there is a suppress message.
    			CloseOutput = false, 
    			Encoding = enc,
    			OmitXmlDeclaration = false,
    			Indent = true
    		};
    		using (System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(ms, xmlWriterSettings))
    		{
    			XmlSerializer s = new XmlSerializer(typeof(T));
    			s.Serialize(xw, obj);
    		}
    
    		return enc.GetString(ms.ToArray());
    	}
    }
