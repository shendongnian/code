	[DataContract()]
	class MyObject {
	 
	    public ImmutableList<string> Strings { get; private set}
	    
	    [DataMember(Name="Strings")]
	    private List<String> _Strings;
	    
	    [OnSerializing()]
	    public void OnSerializing(StreamingContext ctxt){
	    	_Strings = String.ToList();
	    }
	    
	    [OnDeserialized()]
	    public void OnDeserialized(StreamingContext ctxt){
	    	Strings = ImmutableList<string>.Empty.AddRange(_Strings);
	    }
	}
	
