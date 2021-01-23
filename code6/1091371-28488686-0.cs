    class Base {
    	public Base(object value) { 
    		Console.WriteLine ("Base constructor");
    	}
    }
    
    class Child : Base {
    	public Child() : base(DoWorkBeforeBaseConstructor()) { }
    	
    	private static object DoWorkBeforeBaseConstructor() {
    		Console.WriteLine ("doing work");
    		return null;
    	}
    }
