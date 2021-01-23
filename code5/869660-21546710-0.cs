        public static PropertyInfo[] GetPropertiesByType(this Type t)
		{
			if (!typeof (MyBasePropertyClass).IsAssignableFrom(t))
				return new PropertyInfo[0];
			return t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
			        .OrderBy(p => p.Name)
			        .ToArray();
		}
