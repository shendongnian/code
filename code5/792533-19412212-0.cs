		static void testFunction<T>(T obj) where T : class, IA, IB
		{
			IA obj2 = obj;
			if (obj == obj2)
			{
			}
		}
