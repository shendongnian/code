    using System.Reflection;
    using System.Reflection.Emit;
    public class Program
    {
        public static void Main(string[] args)
        {
            var dynMethod = new DynamicMethod("test1", typeof(void), Type.EmptyTypes);
            var gen = dynMethod.GetILGenerator();
            gen.EmitWriteLine("Test");
            gen.Emit(OpCodes.Ret);
            
            var dynMethod2 = new DynamicMethod("test2", typeof(void), Type.EmptyTypes);
            gen = dynMethod2.GetILGenerator();
            gen.Emit(OpCodes.Call, dynMethod);
            gen.Emit(OpCodes.Ret);
            var method2 = (Action)dynMethod2.CreateDelegate(typeof(Action));
            method2();
        }
    }
