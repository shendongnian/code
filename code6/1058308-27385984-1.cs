    public TestModel DeserializeIt(XDocument xDoc)
    {
    	TestModel result;
    	var serializer = new XmlSerializer(typeof(TestModel), xDoc.Root.Name.Namespace.ToString());
    
    	using(var sr = new StringReader(xDoc.ToString()))
    	{
    		result = (TestModel)serializer.Deserialize(sr);
    	}
    	
    	return result;
    }
