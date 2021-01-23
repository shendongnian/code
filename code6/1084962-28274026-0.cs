    public class MyClassWrapper
    {
        MyClass _obj;
    	public MyClassWrapper(MyClass obj)
    	{
    		_obj = obj;	
    	}
    	
    	public void Invoke(Action<MyClass> action)
    	{
    		action(_obj);
    	}
    	
    	public U Invoke<U>(Func<MyClass, U> func)
    	{
    		return func(_obj);
    	}
    	
    	public void ChangeTo(MyClass obj)
    	{
    		_obj = obj;
    	}
    }
