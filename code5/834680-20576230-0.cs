    public class SomeContract
    {
    #if WINDOWS_PHONE8
    	[DataContract]
    #endif
    	public string MyProperty { get; set; }
    }
