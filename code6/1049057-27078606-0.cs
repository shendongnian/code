    // base class you can use in dictionaries
	// note that is does not store any data type
	class DataItem 
	{
		// method called from outside
		// for processing the item
		public abstract void GetProcessed(Processor p);
	}
    
    // DataItem which stores a double
	class DoubleDataItem  : DataItem
	{
		public double Data{get;set;}
        
        public override void GetProcessed(Processor p)
		{
			p.Process(this);
		}
	}
 
    // DataItem which stores a string
	class StringDataItem : DataItem
	{
		public string Data {get;set}
        public override void GetProcessed(Processor p)
		{
			p.Process(this);
		}
    }
