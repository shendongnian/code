    public Interface IRecord
    {
        ...
    }
    public class BaseRecord:IRecord
    {
        //hold record information
    }
    
    public class DerivedRecordOne : BaseRecord,IRecord
    {
        //hold additional record information
    }
    
    public class BaseRecordProcessor
    {
    
        public virtual DoStuff(IRecord record)
        {
            //do stuff
        }
    }
    public class DerivedRecordProcessor : BaseRecordProcessor
    {
        public override DoStuff(IRecord record)
        {
            //do stuff
        }
    }
