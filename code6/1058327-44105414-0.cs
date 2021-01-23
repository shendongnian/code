    void Main()
    {
    	Poco p = new Poco();
    	p.Items.Add("foo");
    	p.Items.Add("bar");
	
    	p.Dump(); // Linqpad command to show a visual objet dump in the output pane
	
    	String serialized = Newtonsoft.Json.JsonConvert.SerializeObject( p );
	
    	serialized.Dump();
        // serialized == "{"Items":["foo","bar"]}"
	
    	Poco p2 = (Poco)Newtonsoft.Json.JsonConvert.DeserializeObject( serialized, typeof(Poco) );
	
    	p2.Dump();
    }
    class Poco
    {
    	public List<String> Items { get; } = new List<String>();
    }
