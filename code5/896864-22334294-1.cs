        void Main()
    {
    	var dynJson = JsonConvert.DeserializeObject<MyThing>("{\"a\":13,\"o\":215,\"f\":[\"g\",\"i\"]}");
    	
    	Console.WriteLine(dynJson.a);
    	Console.WriteLine(dynJson.o);
    	foreach(var something in dynJson.f){
    		Console.WriteLine(something);
    	}
    }
    
    public class MyThing {
    
    	public int a {get;set;}
    	public int o {get;set;}
    	public List<string> f {get;set;}
    }
