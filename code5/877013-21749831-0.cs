		private static T ConvertAndValidate<T>(string bla)
		{
			T ret = default(T);
			if (typeof(System.Collections.IList).IsAssignableFrom(typeof(T)))
			{
				if (typeof(T).GetGenericArguments().Length > 0)
				{
					ret = (T)Activator.CreateInstance(typeof(T));
				}
			}
			return ret;
		}
