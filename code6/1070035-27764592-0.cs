    using System;
    using System.Reflection;	
    
    public abstract class B
    {
    	private Type _type;
    	
    	protected B()
    	{
    		_type = GetType();
    	}
    	
    	public object Get(string name)
    	{
    		
    		object data = null;
    		
    		var field = _type.GetField(name);
    		if(field != null)
    		{
    			data = field.GetValue(this);
    		}
    		else
    		{
    			var member = _type.GetProperty(name);
    			if(member != null)
    			{
    				data = member.GetValue(this);
    			}
    		}
    	 
    		return data;
    	}
    	
    	public T Get<T>(string name)
    	{
    		var data = Get(name);
    		
    		if(data != null && data is T)
    			return (T)data;
    		
    		return default(T);
    	}
    	
    	public void Set<T>(string name, T data)
    	{
    		var field = _type.GetField(name);
    		if(field != null)
    		{
    			field.SetValue(this, data);
    		}
    		else
    		{
    			var member = _type.GetProperty(name);
    			if(member != null)
    			{
    				member.SetValue(this, data);
    			}
    		}
    	}
    }
    	
    public class B1 : B
    {
    	public int Info1 {get; set;}
    }
    
    public class B2 : B
    {
    	public string Info2;
    }
    	
    public class C
    {
    	public object mObject;
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var b1 = new B1();
    		var b2 = new B2();
    		b1.Info1 = 1;
    		b2.Info2 = "sad";
    		
    		Console.WriteLine(b1.Get<int>("Info1"));
    		Console.WriteLine(b2.Get("Info2"));
    		
    		Console.WriteLine("\r\n\r\n");
    		
    		var c  = new C();
    		c.mObject = new B1();
    		(c.mObject as B).Set("Info1", 123);
    		Console.WriteLine((c.mObject as B).Get("Info1"));
    	}
    }
