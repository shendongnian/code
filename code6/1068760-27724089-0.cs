    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		A foo = new A();
            B bar = new B(foo);
            foo.data = 20;
    
            Console.WriteLine(bar.a.data); // prints 9
    	}
    }
    
    class A
    {
        public int data = 9;
    	public A()
    	{
    	}
    	public A(A a)
    	{
    		this.data=a.data;
    	}
    }
    class B
    {
        public B(A a_) { a = new A(a_); }
        public A a;
    }
