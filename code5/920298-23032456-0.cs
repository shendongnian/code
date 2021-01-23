	class Program
	{
		interface MyInterface<SomeType>
		{
			SomeType getObjectFromDatabase ();
		}
		class A : MyInterface<A> { public A getObjectFromDatabase () { return new A (); } }
		class B : MyInterface<B> { public B getObjectFromDatabase () { return new B (); } }
		class Program2
		{
			static void Main ()
			{
				A a1, a2;
				a1 = new A ();
				a2 = a1.getObjectFromDatabase ();
				B b1, b2;
				b1 = new B ();
				b2 = b1.getObjectFromDatabase ();
			}
		}
	}
