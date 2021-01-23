    void Main()
    {
    	var pg = new Castle.DynamicProxy.ProxyGenerator();
    	var typeA = typeof(A);
    	var interceptor = 
    		new FooInterceptor(
    			str => Console.WriteLine("intercepted {0}", str));
    	IEnumerable<A> objs = Assembly
    		.GetExecutingAssembly()
    		.GetTypes()
    		.Where(t => t.IsSubclassOf(typeA))
    		.Select(t => (A)(pg.CreateClassProxy(t, interceptor)));
    	
    	foreach(A a in objs)
    	{
    		a.CallFoo("hello world");
    	}
    }
    
    public class A
    {
    	public void CallFoo(string someString){
    		Foo(someString);
    	}
       	protected virtual void Foo(string someString)
    	{
    		Console.WriteLine("base Foo {0}", someString);
    	}
    }
    public class B : A {}
    
    public class C : A {}
    
    public class D : A {}
    
    public class FooInterceptor : IInterceptor
    {
    	Action<string> interceptorDelegate;
    	public Interceptor(Action<string> interceptorDelegate)
    	{
    		this.interceptorDelegate = interceptorDelegate;
    	}
        public void Intercept(IInvocation invocation)
        {
    		var isFooCall = invocation.Method.Name == "Foo";
    		if(isFooCall)
    		{
    			interceptorDelegate
    				.Invoke((string)(invocation.Arguments[0]));
    		}
    		else
    		{
    			invocation.Proceed();
    		}
        }
    }
