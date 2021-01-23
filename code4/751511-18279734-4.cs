    public static class MyFactory
    {
    	public static MyClass CreateMyClass(Func<string> x = null)
    	{
    		var myClass = new MyClass()
    		if (x != null)
                    myClass.x = x();
    		return myClass;
    	}
    }
