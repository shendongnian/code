    public void Method1(int i)
    {
    	this.PredicateMethod(
    		NullFunc(() => SomeMethod(i, 1, 2)),
    		NullFunc(() => SomeMethod2(1, "RandomString")));
    }
    
    public string Method2()
    {
    	return this.PredicateMethod(
    		() => OtherMethod(1, true), 
    		() => OtherMethod2(1, "RandomString", 2));
    }
    
    private Func<object> NullFunc(Action a)
    {
    	a();
    	return null;
    }
    		
    private T PredicateMethod<T>(Func<T> trueMethod, Func<T> falseMethod)
    {
    	if (isThisTrue())
    	{
    		return trueMethod();
    	}
    	else
    	{
    		return falseMethod();
    	}
    }
