    void Main()
    {
    	A foo = new A();
    	B bar = new B();
    	
    	CopyValues(foo, bar);
    }
    
    public void CopyValues(object f, object t)
    {
    	Type fr = f.GetType();
    	Type target = t.GetType();
        var bindingFlags = BindingFlags.Public| BindingFlags.NonPublic | BindingFlags.Instance;
    	
    	foreach(FieldInfo source in fr.GetFields(bindingFlags))
    	{
    		FieldInfo fi = target.GetField(source.Name, bindingFlags);
    		if(fi != null)
    			fi.SetValue(t, source.GetValue(f));
    	}
    }
