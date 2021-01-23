    using System.Reflection;
    using System.Reflection.Emit;
    public class Program
    {
    	public static void Main()
    	{
    		CreateAndInvokeMethod(false, new Base(), typeof(Base).GetMethod("Test"));
    		CreateAndInvokeMethod(true, new Base(), typeof(Base).GetMethod("Test"));
    		CreateAndInvokeMethod(false, new C(), typeof(Base).GetMethod("Test"));
    		CreateAndInvokeMethod(true, new C(), typeof(Base).GetMethod("Test"));
    		
    		CreateAndInvokeMethod(false, new Base(), typeof(C).GetMethod("Test"));
    		CreateAndInvokeMethod(true, new Base(), typeof(C).GetMethod("Test"));
    		CreateAndInvokeMethod(false, new C(), typeof(C).GetMethod("Test"));
    		CreateAndInvokeMethod(true, new C(), typeof(C).GetMethod("Test"));
    	}
    
    	private static void CreateAndInvokeMethod(bool useVirtual, Base instance, MethodInfo methodInfo)
    	{
    		var dynMethod = new DynamicMethod("test", typeof (void), 
                new Type[] { typeof(Base) });
    		var gen = dynMethod.GetILGenerator();
    		gen.Emit(OpCodes.Ldarg_0);
    		OpCode code = useVirtual ? OpCodes.Callvirt : OpCodes.Call;
    		gen.EmitCall(code, methodInfo, null);
    		gen.Emit(OpCodes.Ret);
    		var method = (Action<Base>)dynMethod.CreateDelegate(typeof (Action<Base>));
    		try
    		{
    			method(instance);
    		}
    		catch (Exception e)
    		{
    			Console.WriteLine("{0}: {1}", e.GetType(), e.Message);
    		}
    	}
    
    	public class Base
    	{
    		public virtual void Test()
    		{
    			Console.WriteLine("Base");
    		}
    	}
    
    	public class C : Base
    	{
    		public override void Test()
    		{
    			Console.WriteLine("C");
    		}
    	}
    }
