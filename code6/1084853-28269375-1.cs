    class X
    {
    	public bool test() { return false; }
    }
    
    var x = new X();
    var runtimeType = x.GetType();
    var method = runtimeType.GetMethod("test");
