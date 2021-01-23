    [Serializable, XmlRoot(ElementName = "TestModel")]
    public class TestModel
    {
    	public TestModel()
    	{
    		TestElements = new List<TestModelChildren>();
    	}
    
    	[XmlElement("TestModelChildren")]
    	public List<TestModelChildren> TestElements { get; set; }
    }
