    public void PostMethod(string param1 = "All", string param2 = "All",
    	string param3 = "All", string param4 = "All") {
    
    	var results = query.Where(x => param1 == "All" || x.Prop1 == param1)
    		.Where(x => param2 == "All" || x.Prop2.Contains(param2))
    		.Where(x => param3 == "All" || x.Prop3.StartsWith(param3))
    		.Where(x => param4 == "All" || x.Prop4.EndsWith(param4));
    }
