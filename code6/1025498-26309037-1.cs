    public class DerivedRecordProcessor : BaseRecordProcessor
    {
        public override DoStuff (BaseRecord record)
        {
            DerivedRecordOne derivedRecordOne = record as DerivedRecordOne;
            if( null != derivedRecordOne ) 
            {
                // Do DerivedRecordOne stuff here using local variable derivedRecordOne 
            } 
            else 
            {
               // do base stuff
               base.DoStuff( record );
            }
        }
    }
