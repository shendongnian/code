	using System;
	using System.Reflection;
	using System.Reflection.Emit;
	public delegate void CallBadFunction(Delegate d, Callback c);
	public delegate void Callback(ref int i);
	static class Program
	{
		static int i;
		static object BadMethod()
		{
			return i;
		}
		static MethodInfo GetBadMethod()
		{
			return typeof(Program).GetMethod("BadMethod", BindingFlags.Static | BindingFlags.NonPublic);
		}
		static void Main()
		{
			var badMethod = GetBadMethod();
			var assembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("-"), AssemblyBuilderAccess.Run);
			var module = assembly.DefineDynamicModule("-");
			var badDelegate = module.DefineType("BadDelegateType", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Sealed, typeof(MulticastDelegate));
			var badDelegateCtor = badDelegate.DefineConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, CallingConventions.Standard, new Type[] { typeof(object), typeof(IntPtr) });
			badDelegateCtor.SetImplementationFlags(MethodImplAttributes.Runtime | MethodImplAttributes.Managed);
			var badDelegateInvoke = badDelegate.DefineMethod("Invoke", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.NewSlot | MethodAttributes.HideBySig, typeof(int).MakeByRefType(), Type.EmptyTypes);
			badDelegateInvoke.SetImplementationFlags(MethodImplAttributes.Runtime | MethodImplAttributes.Managed);
			var badDelegateType = badDelegate.CreateType();
			var method = module.DefineGlobalMethod("-", MethodAttributes.Public | MethodAttributes.Static, typeof(void), new[] { typeof(Delegate), typeof(Callback) });
			var il = method.GetILGenerator();
			il.Emit(OpCodes.Ldarg_1);
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Castclass, badDelegate);
			il.Emit(OpCodes.Callvirt, badDelegateInvoke);
			il.Emit(OpCodes.Callvirt, typeof(Callback).GetMethod("Invoke"));
			il.Emit(OpCodes.Ret);
			module.CreateGlobalFunctions();
			var callBadFunction = (CallBadFunction)Delegate.CreateDelegate(typeof(CallBadFunction), module.GetMethod("-"));
			callBadFunction(badMethod.CreateDelegate(badDelegateType), (ref int i) =>
			{
				i++;
			});
		}
	}
