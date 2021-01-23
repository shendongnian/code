    public static TestA Deserialize(JsonTextReader reader)
    {
    	TestA a = new TestA();
    
    	reader.Read();
    	reader.Read();
    	if (!reader.Value.Equals("TestBs"))
    		throw new Exception("Expected property 'TestBs' first");
    	reader.Read(); //Start array
    	a.TestBs = DeserializeTestBs(reader); //IEnumerable property last
    	return a;
    }
