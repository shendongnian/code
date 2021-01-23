    void Main()
    {
    	var json = @"{ 1: { 'a': 'anything', 'b': 987, }, 2: { 'a': 'something', 'b': 123, } }";
    	JsonConvert.DeserializeObject<IDictionary<int, MyClass>>(json).Dump();	
    }
    
    // Define other methods and classes here
    class MyClass 
    {
    	public string A { get; set; }
    	public int B { get; set; }
    }
