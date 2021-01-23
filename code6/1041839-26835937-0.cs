    	public static IEnumerable<FieldInfo> GetAllFields(Type t)
		{
			while (t != null)
			{
				foreach (FieldInfo field in t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly))
				{
					yield return field;
				}
				t = t.BaseType;
			}
		}
