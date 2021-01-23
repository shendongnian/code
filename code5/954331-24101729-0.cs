	public static void Transform(Stream stream, string xml, string xslt)
	{
		var myDoc = new XPathDocument(xml);
		var myXL = new XslCompiledTransform();
		myXL.Load(xslt);
		using(var myWriter = new XmlTextWriter(stream, Encoding.Default))
		{
			myXL.Transform(myDoc, null, myWriter);
			myWriter.Flush();
			myWriter.Close();
		}
	}
