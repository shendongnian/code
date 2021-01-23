    using System;
    using System.Reflection;
    class A
    {
        public int i;
    	public A()
    	{
    		Console.WriteLine("A()");
    	}
    	private A(int j)
    	{
    		Console.WriteLine("A(" + j + "): i = " + i);
    	}
    }
    static class Program
    {
    	static void Main(string[] args)
    	{
    		var a = new A();
            a.i = 3;
    		var constructor = a.GetType().GetConstructor(BindingFlags.Instance | BindingFlags.Public |BindingFlags.NonPublic, null, new Type[] { typeof(int) }, null);
            constructor.Invoke(a, new object[] { 3 });
    	}
    }
