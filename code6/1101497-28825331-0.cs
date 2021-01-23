    public class MyClass
    {
        private readonly IInteropThing _interop;
	
        public int Id { get; set; }
	    public MyClass (IInteropThing _interop)
	    {
		    _interop = interop;
	    } 
        // this is only static method
        public static GetMyClass(int id)
        {
            // get it in this case from unmanaged code
            return new MyClass(_interop.GetMyClassStruct(id));
        }
    }
