    public class BaseRecordProcessor<T> where T : BaseRecord
    {
    	public virtual void DoStuff(T myObj)
    	{
    	}
    }
    
    public class DerivedRecordProcessor : BaseRecordProcessor<DerivedRecordOne>
    {
    	public override void DoStuff(DerivedRecordOne derived)
    	{
    	}
    }
