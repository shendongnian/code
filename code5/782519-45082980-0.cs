    using System;
    
    namespace Test
    {
    	public class A 
    	{
    	    public string Info { get; set; }
    	    /* much more data */
    	}
    	
    	public class B
    	{
    	    private A m_instanceOfA;
    	
    	    public B(A a) { m_instanceOfA = a; }
    	
    	    public string Info
    	    {
    	    	get { return m_instanceOfA.Info; }
    	    	set { m_instanceOfA.Info = value; }
    	    }
    	
    	    // requires an instance of a private object, this establishes our pseudo-friendship
    	    internal A GetInstanceOfA(C.AGetter getter) { return getter.Get(m_instanceOfA); }
    	
    	    /* And some more data of its own*/
    	}
    	
    	public class C
    	{
    	    private A m_instanceOfA;
    	
    	    private static AGetter m_AGetter; // initialized before first use; not visible outside of C
    	
    	    // class needs to be visible to B, actual instance does not (we call b.GetInstanceOfA from C)
    	    internal class AGetter
    	    {
    	        static AGetter() { m_AGetter = new AGetter(); } // initialize singleton
    	
    	        private AGetter() { } // disallow instantiation except our private singleton in C
    	
    	        public A Get(A a) { return a; } // force a NullReferenceException if calling b.GetInstanceOfA(null)
    	    }
    	
    	    public C(B b)
    	    {
    	    	// ensure that m_AGetter is initialized, then assign m_instanceOfA from b
    	    	System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(AGetter).TypeHandle); 
    	    	m_instanceOfA = b.GetInstanceOfA(m_AGetter);
    	    }
    	    
    	    public string Info
    	    {
    	    	get { return m_instanceOfA.Info; }
    	    	set { m_instanceOfA.Info = value; }
    	    }
    	
    	    /* And some more data of its own*/
    	}
    	
    	public class Test
    	{
    		public static void Main()
    		{
    			A a = new A();
    			B b = new B(a);
    			C c = new C(b);
    			c.Info = "Hello World!";
    			Console.WriteLine(a.Info);
    		}
    	}
    }
