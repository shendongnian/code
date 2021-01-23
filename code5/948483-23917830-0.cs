    // 1. Reflection
    public void SetByReflection(){
    	Car cObj = new Car();
    	string propName = "Break";
    	cObj.GetType().GetProperty(propName).SetValue(cObj, "diskBreak");
    	Console.WriteLine (cObj.Break);
    }
    
    // 2. ExpandoObject
    public void UseExpandoObject(){
    	dynamic car = new ExpandoObject();
    	string propName = "Break";
    	((IDictionary<string, object>)car)[propName] = "diskBreak";
    	Console.WriteLine (car.Break);
    }
