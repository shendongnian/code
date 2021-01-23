    public class DerivedRecordProcessor : BaseRecordProcessor
    {
        public override DoStuff (BaseRecord record)
        {
            if( record is DerivedRecordOne ) 
            {
                // Do DerivedRecordOne stuff here
            } 
            else 
            {
               // do base stuff
               base.DoStuff( record );
            }
        }
    }
