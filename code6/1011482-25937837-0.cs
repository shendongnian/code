    public void main()
    {
        // [...]
        ProcessXsltSort(MyXmlDocument.DocumentElement);
    }
    // untested since i'm not coding directly in c# dotnet
    private static void ProcessXsltSort(XmlNode nodes)
	{
		// "nodes" into XmlReader
		StringReader documentStringReader = new StringReader(nodes.OuterXml);
		XmlReader documentXmlReader = XmlReader.Create(documentStringReader);
		
		// xsl into XmlReader
		StringReader stylesheetStringReader = new StringReader(XsltSortingString());
		XmlReader stylesheetXmlReader = XmlReader.Create(stylesheetStringReader);
		
		// output
		StringBuilder outputBuilder = new StringBuilder();
		XmlWriter outputXmlWriter = XmlWriter.Create(outputBuilder);
		
		// transform
		XlsCompiledTransform transformer = new XslCompiledTransform();
		transformer.Load(stylesheetXmlReader);
		transformer.Transform(documentXmlReader,outputXmlWriter);
		
		// write output back
		XmlDocument transformedXmlDocument = new XmlDocument();
		transformedXmlDocument.LoadXml(outputBuilder.ToString());
		nodes.InnerXml = transformedXmlDocument.DocumentElement.InnerXml;
		
		// recursive loop
		foreach (XmlNode subnodes in nodes.SelectNodes("treenode/nodes"))
		{
			ProcessXsltSort(subnodes);
		}
	}
