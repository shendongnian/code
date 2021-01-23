    	public static void Main()
    	{
    		// print each value
    		foreach(var w in getListInsideSlash("a/b/c/d"))
    			Console.WriteLine(w);
    		
    		Console.WriteLine("-");
    		
    		foreach(var w in getListInsideSlash("a/b/c"))
    			Console.WriteLine(w);
    		
    		
    	}
    	
    	public static string[] getListInsideSlash(string a){
    		return a.Split('/').Skip(1).Take(a.Split('/').Count() -2).ToArray<string>();	
    	}
   
