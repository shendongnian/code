    using System.Reflection;
    using System.Reflection.Emit;
    
    public class Program
    {
        public static void Main()
        {
    		// Base parameter, Base method info
            CreateAndInvokeMethod(false, new Base(), typeof(Base), typeof(Base).GetMethod("Test"));
            CreateAndInvokeMethod(true, new Base(), typeof(Base), typeof(Base).GetMethod("Test"));
            CreateAndInvokeMethod(false, new C(), typeof(Base), typeof(Base).GetMethod("Test"));
            CreateAndInvokeMethod(true, new C(), typeof(Base), typeof(Base).GetMethod("Test"));
    		Console.WriteLine();
    		
    		// Base parameter, C method info
            CreateAndInvokeMethod(false, new Base(), typeof(Base), typeof(C).GetMethod("Test"));
            CreateAndInvokeMethod(true, new Base(), typeof(Base), typeof(C).GetMethod("Test"));
            CreateAndInvokeMethod(false, new C(), typeof(Base), typeof(C).GetMethod("Test"));
            CreateAndInvokeMethod(true, new C(), typeof(Base), typeof(C).GetMethod("Test"));
    		Console.WriteLine();
    		
    		// C parameter, C method info
            CreateAndInvokeMethod(false, new C(), typeof(C), typeof(Base).GetMethod("Test"));
            CreateAndInvokeMethod(true, new C(), typeof(C), typeof(Base).GetMethod("Test"));
            CreateAndInvokeMethod(false, new C(), typeof(C), typeof(C).GetMethod("Test"));
            CreateAndInvokeMethod(true, new C(), typeof(C), typeof(C).GetMethod("Test"));
        }
    
        private static void CreateAndInvokeMethod(bool useVirtual, Base instance, Type parameterType, MethodInfo methodInfo)
        {
            var dynMethod = new DynamicMethod("test", typeof (string), 
                new Type[] { parameterType });
            var gen = dynMethod.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            OpCode code = useVirtual ? OpCodes.Callvirt : OpCodes.Call;
            gen.Emit(code, methodInfo);
            gen.Emit(OpCodes.Ret);
    		string res;
            try
            {
    			res = (string)dynMethod.Invoke(null, new object[] { instance });
            }
            catch (TargetInvocationException ex)
            {
    			var e = ex.InnerException;
                res = string.Format("{0}: {1}", e.GetType(), e.Message);
            }
    		
    		Console.WriteLine("UseVirtual: {0}, Result: {1}", useVirtual, res);
        }	
    }
    
    public class Base
    {
        public virtual string Test()
        {
            return "Base";
        }
    }
    
    public class C : Base
    {
        public override string Test()
        {
            return "C";
        }
    }
