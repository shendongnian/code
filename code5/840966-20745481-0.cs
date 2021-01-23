    void Main()
    {
    	var e = new example
    	{
    		property1 = "a",
    		property2 = 42,
    		property3 = 100
    	};
    	
    	string s = string.Join("&", e.GetType().GetProperties().Select(p => p.Name + "=" + p.GetValue(e, null)));
    	// s= property1=a&property2=42&property3=100
    }
    
    public class example {
        public string property1 {get;set;}
        public int property2 {get;set;}
        public double property3 {get;set;}
    }
