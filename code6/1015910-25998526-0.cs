    void Main()
    {
    	Test(Foo.A, Foo.B, Foo.C);	
    }
    
    // External Library Call
    public void Test(IEnumerable values){
    	values.Dump();
    }
    
    public enum Foo {
    	A,B,C
    }
    
    public void Test(params Foo[] values){
    	Test(ToObjectArray(values.Cast<int>()));
    }
    
    public static object[] ToObjectArray<T>(IEnumerable<T> values)
    {
        var array = values.ToArray();
        var objArray = new object[array.Length];
        array.CopyTo(objArray, 0);
        return objArray;
    }
