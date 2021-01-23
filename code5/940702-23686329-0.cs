    class Data
    {
    	public int ID { get; set; }
    	public string Value { get; set; }
    	public Dictionary<string, Data> Children { get; set; }
    
    	public Data()
    	{
    		Children = new Dictionary<string, Data>();
    	}
    	public Data(int Id, string value) : this()
    	{
    		this.ID = Id;
    		this.Value = value;
    	}
    
    	public Data this[string name]
    	{
    		get { 
    			if (Children.ContainsKey(name)) return Children[name];
    			else {
    				Children.Add(name, new Data());
    				return Children[name];
    			}
    		}
    		set {
    			if (Children.ContainsKey(name)) Children[name] = value;
    			else Children.Add(name, value);
    		}
    	}
    }
