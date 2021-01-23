    public class KVEntry : Dictionary<string,string>, LINQPad.ICustomMemberProvider
    {
    	IEnumerable<string> ICustomMemberProvider.GetNames() 
        {
            return Keys;
        }
    
        IEnumerable<Type> ICustomMemberProvider.GetTypes ()
        {
            return Enumerable
    				.Range(0,Count)
    				.Select (e => typeof(string));
        }
    
        IEnumerable<object> ICustomMemberProvider.GetValues ()
        {
            return Values;
        } 
    	
    	public KVEntry(Dictionary<string,string> data) : base(data){}
    }
