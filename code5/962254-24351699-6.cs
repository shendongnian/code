    internal class Program
    {
    	[MethodImpl(MethodImplOptions.NoInlining)]
    	private static void Test()
    	{
    		var b = GetA();
    		b.GenericVirtual<string>();
    		b.GenericVirtual<int>();
    		b.GenericVirtual<StringBuilder>();
    		b.GenericVirtual<int>();
    		b.GenericVirtual<StringBuilder>();
    		b.GenericVirtual<string>();
    		b.NormalVirtual();
    	}
    
    	[MethodImpl(MethodImplOptions.NoInlining)]
    	private static A GetA()
    	{
    		return new B();
    	}
    
    	private class A
    	{
    		public virtual void GenericVirtual<T>()
    		{
    		}
    
    		public virtual void NormalVirtual()
    		{
    		}
    	}
    
    	private class B : A
    	{
    		public override void GenericVirtual<T>()
    		{
    			base.GenericVirtual<T>();
    			Console.WriteLine("Generic virtual: {0}", typeof(T).Name);
    		}
    
    		public override void NormalVirtual()
    		{
    			base.NormalVirtual();
    			Console.WriteLine("Normal virtual");
    		}
    	}
    
    	public static void Main(string[] args)
    	{
    		Test();
    		Console.ReadLine();
    		Test();
    	}
    }
