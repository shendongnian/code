	public class B { }
	
	public class C : A<B, C> 
	{ 
		public C Foo(B b)
		{
			return C.Convert(b);
		}
	}
