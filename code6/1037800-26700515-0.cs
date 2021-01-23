	public static class DelegateCreator
	{
		private static readonly Func<Type[],Type> MakeNewCustomDelegate = (Func<Type[],Type>)Delegate.CreateDelegate(typeof(Func<Type[],Type>), typeof(Expression).Assembly.GetType("System.Linq.Expressions.Compiler.DelegateHelpers").GetMethod("MakeNewCustomDelegate", BindingFlags.NonPublic | BindingFlags.Static));
		
		public static Type NewDelegateType(Type ret, params Type[] parameters)
		{
			Type[] args = new Type[parameters.Length];
			parameters.CopyTo(args, 0);
			args[args.Length-1] = ret;
			return MakeNewCustomDelegate(args);
		}
	}
 
    DelegateCreator.NewDelegateType(typeof(int)) //returns non-generic variant of Func<int>
