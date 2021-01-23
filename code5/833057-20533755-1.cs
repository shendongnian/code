    public class KVEntry : Dictionary<string,string>, LINQPad.ICustomMemberProvider
    {
    	IEnumerable<string> ICustomMemberProvider.GetNames() 
        {
            return Keys;
        }
    
        IEnumerable<Type> ICustomMemberProvider.GetTypes()
        {
            return Enumerable
    				.Repeat(typeof(string),Count);
        }
    
        IEnumerable<object> ICustomMemberProvider.GetValues()
        {
            return Values;
        } 
    	
    	public KVEntry(Dictionary<string,string> data) : base(data){}
    }
