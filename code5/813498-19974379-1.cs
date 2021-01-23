    void Main()
    {
    	var typeMapping = new Dictionary<Type, Func<object, dynamic>>(){
    		{typeof(A), a => (A)a}
    	};
    	var array = new[]{new A(){ o = new Object()	},new A(){ o = new Object()	},new A(){ o = new Object()	},new A(){ o = new Object()	},};	
    	var objectArray = array.OfType<object>();
    	objectArray.Select(a => typeMapping[a.GetType()](a)).Dump();
    	
    }
    	
    class A{
    	public object o {get;set;}
    }
