    void Main()
    {
    	var types = new List<object>{
    		(byte)1,
    		(short)1,
    		(int)1,
    		(long)1,
    		(double)1,
    		(decimal)1,
    		(float)1,
    		"omg afd obj amd",
    		"omg afd obj amd omg afd obj amd omg afd obj amd omg afd obj amd omg afd obj amd omg afd obj amd omg afd obj amd ",
    		new Exception("Holy Maceral"),
    	};
    	
    	foreach(var o in types)
    	{
    		Console.WriteLine("Size of {0} == {1}",o.GetType().Name,o.SizeOf());
    	}
    }
    public static class ExtensionMethods
    {
    	public static int SizeOf(this object obj)
    	{
    		int size = 0;
    		if(obj == null)
    			return 0;
    		Type type = obj.GetType();
    		
    		if(type.IsValueType)
    		{
    			return type.SizeOfType();
    		}
    		
    		PropertyInfo[] info = type.GetProperties();
    		foreach(PropertyInfo property in info)
    		{
    			if(property.GetIndexParameters().Length > 0)
    			{
    				var ip = property.GetIndexParameters().First();
    				//Console.WriteLine(info);
    				var len = (int)info.FirstOrDefault(x=>x.Name == "Length" || x.Name == "Count").GetValue(obj);
    				for(var i = 0;i<len;i++)
    				{
    					size += property.GetValue(obj,new object[1]{i}).SizeOf();
    				}
    			}
    			else if(property.GetGetMethod().ReturnType.IsArray)
    			{
    				var arr = property.GetGetMethod().Invoke(obj,null);
    				foreach(var a in (Array)arr)
    				{
    					size+= a.SizeOf();
    				}
    			}
    			else if(property.PropertyType.IsValueType)
    			{
    				var val = property.GetValue(obj,null);
    				unsafe
    				{
    					size += property.PropertyType.SizeOfType();
    				}
    			}
    			else{
    				size += property.GetValue(obj,null).SizeOf();
    			}
    		}
    		return size;
    	}
    	
    	public static int SizeOfType(this Type type)
    	{
    		if(type.IsValueType == false)
    			throw new ArgumentException("type must be value type");
    		
    		return Marshal.SizeOf(type);
    	}
    }
