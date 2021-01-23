    public class B : A
    {
    	public override bool ShouldSerializeProperty1()
    	{
    		return false;
    	}
    }
    
    public class C : A
    {
    	public override bool ShouldSerializeProperty2()
    	{
    		return false;
    	}
    }
