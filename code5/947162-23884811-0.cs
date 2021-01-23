    abstract class Parent<T>
    {
        public abstract T SomeMethod();    
    }
    
    class Child : Parent<ReturnChild>
    {
        // Note the return type
        public override ReturnChild SomeMethod()
    	{
    	   return new ReturnChild();
    	}
    }
    
    void Main()
    { 
        var p = new Child(); // This works
        Child c = p as Child; // This doesn't work with generics
    }
