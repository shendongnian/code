    public class MyModel
     {
    	public string EncodedOutputMessage { get; set; }
    	
    	Public Transform()
    	{
    		// Do something
    		SetTransformResult(xsl, intputMsgPath);
    	}
    	
    	private void SetTransformResult(XslCompiledTransform xsl, string intputMsgPath)
    	{
    		MemoryStream stream = new MemoryStream();
    		XmlWriter xmlWriter = XmlWriter.Create(stream);
    		xsl.Transform(intputMsgPath, xmlWriter);
    		xmlWriter.Close();
    
    		XmlDocument root = new XmlDocument();
    		stream.Position = 0; // rewind the pointer to the beginning of the stream
    		root.Load(stream);
    		XmlNodeList nodes = root.GetElementsByTagName("BodyXhtml");
    		if (nodes.Count == 1)
    		{
    			EncodedOutputMessage = HttpUtility.HtmlEncode(nodes[0].InnerXml);
    		}
    		stream.Close();
    	}
    }
