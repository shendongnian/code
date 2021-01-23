    class A{
    	public A()
    	{
    		var props = this.GetType()
                    .GetProperties()
                    .Where(prop => prop.PropertyType == typeof(int));
    		foreach(var prop in props)
    		{
    			prop.SetValue(this, -1);
    		}
    	}
    	public int ValA{get; set;}
    	public int ValB{get; set;}
    	public int ValC{get; set;}
    }
