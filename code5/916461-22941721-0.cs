    MessageBuffer buffer = request.CreateBufferedCopy(int.MaxValue);
    
    messageContentType = WebOperationContext.Current.IncomingRequest.ContentType;
    
    try
    {
    	using (MemoryStream mstream = new MemoryStream())
    	{
    		buffer.WriteMessage(mstream);
    		mstream.Position = 0;
    
    		if (messageContentType.Contains("multipart/related;"))
    		{
    			Encoding[] encodings = new Encoding[1];
    			encodings[0] = Encoding.UTF8;
    
    			// MTOM
    			using (XmlDictionaryReader reader = XmlDictionaryReader.CreateMtomReader(mstream, encodings, messageContentType, XmlDictionaryReaderQuotas.Max))
    			{
    				XmlDocument msgDoc = new XmlDocument();
    				msgDoc.PreserveWhitespace = true;
    				msgDoc.Load(reader);
    
    				requestAsString = msgDoc.OuterXml;
    
    				reader.Close();
    			}
    		}
    		else
    		{
    			// Text
    			using (StreamReader sr = new StreamReader(mstream))
    			{
    				requestAsString = sr.ReadToEnd();
    			}
    		}
    
    		request = buffer.CreateMessage();
    	}
    }
    finally
    {
    	buffer.Close();
    }
