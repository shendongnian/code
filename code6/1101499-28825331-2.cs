    public class MyClass
    {
        private readonly IInteropThing _interop;
	
        public int Id { get; set; }
	    public MyClass (IInteropThing interop)
	    {
		    _interop = interop;
	    } 
        public GetMyClass(int id)
        {
            return new MyClass(_interop.GetMyClassStruct(id));
        }
    }
