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
    	
    	foreach(FieldInfo source in fr.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
    	{
    		FieldInfo fi = target.GetField(source.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
    		if(fi != null)
    			fi.SetValue(t, source.GetValue(f));
    	}
    }
