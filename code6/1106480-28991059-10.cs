    public static void Foo<T>(object obj)
    {
        if (!(obj is T)) 
        {
    		var message = 
    			string.Format("Expecting type of <{0}>.", typeof(T).Name);
    		throw new System.ArgumentException(message);
    	}
        // Compiler: 'object' does not contain a definition for 'Cost'
    	// obj.Cost = "11.99"; 
        if(obj is Obj1)
        {
            (obj as Obj1).Cost = "11.99"; 
        }
        else if(obj is Obj2)
        {
            (obj as Obj2).Cost = "11.99"; 
        }
    }
