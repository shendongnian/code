    [DefaultPropertyAttribute("Name")]
    public class Data 
    
    public UInt32 stat;
    [CategoryAttribute("Main Scanner"), DescriptionAttribute("Status"), TypeConverter(typeof(IntToHexTypeConverter ))]
    public UInt32 Status
    {
    	get { return stat; }
    }
