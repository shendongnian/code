    public class A
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    	
    	public virtual bool ShouldSerializeProperty1()
    	{
    		return true;
    	}
    	
    	public virtual bool ShouldSerializeProperty2()
    	{
    		return true;
    	}
    }
