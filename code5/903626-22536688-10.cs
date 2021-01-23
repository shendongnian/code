    public class A
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    	
    	[XmlIgnore]
    	internal bool _ShouldSerializeProperty1 = true;
    	[XmlIgnore]
    	internal bool _ShouldSerializeProperty2 = true;
    	
    	public bool ShouldSerializeProperty1()
    	{
    		return _ShouldSerializeProperty1;
    	}
    	
    	public bool ShouldSerializeProperty2()
    	{
    		return _ShouldSerializeProperty2;
    	}
    }
