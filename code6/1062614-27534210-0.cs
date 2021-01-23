	class BusMessage
	{
		private static readonly Func<BusMessage,Delegate,bool> TryClass;
		
		static BusMessage()
		{
			Type[] classTypes = new Type[]{typeof(int), typeof(string)};
			
			MethodInfo mi = typeof(BusMessage).GetMethod("TryClassifyInternal", BindingFlags.NonPublic | BindingFlags.Static);
			
			var p1 = Expression.Parameter(typeof(BusMessage));
			var p2 = Expression.Parameter(typeof(Delegate));
			Expression exp = null;
			foreach(Type t in classTypes)
			{
				MethodInfo mig = mi.MakeGenericMethod(t);
				Expression e = Expression.Call(mig, p1, Expression.Convert(p2, typeof(Action<>).MakeGenericType(typeof(BusMessage<>).MakeGenericType(t))));
				if(exp == null)
				{
					exp = e;
				}else{
					exp = Expression.OrElse(exp, e);
				}
			}
			
			TryClass = Expression.Lambda<Func<BusMessage,Delegate,bool>>(exp, p1, p2).Compile();
		}
		
		private static bool TryClassifyInternal<T>(BusMessage msg, Action<BusMessage<T>> handleFunction)
		{
			//former TryClassify code
			return false;
		}
		
		public static bool TryClassify(BusMessage msg, Delegate handleFunction)
		{
			return TryClass(msg, handleFunction);
		}
	}
