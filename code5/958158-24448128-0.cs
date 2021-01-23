	public static class Extensions
	{
		//Takes one object and return a new object with type T
		public static T ToType<T>(this object value) where T : new()
		{
			var newValue = (T)Activator.CreateInstance(typeof(T));
			SetProperties(value, newValue);
			return newValue;
		}
		//Sets all properties with same name, from one source to target
		private static void SetProperties(object source, object target)
		{
			var targetType = target.GetType();
			var targetProperties = targetType.GetProperties();
			foreach (var prop in source.GetType().GetProperties())
			{
				if (targetProperties.Any(p => p.Name == prop.Name))
				{
					var propGetter = prop.GetGetMethod();
					var propSetter = targetType.GetProperty(prop.Name).GetSetMethod();
					var valueToSet = propGetter.Invoke(source, null);
					propSetter.Invoke(target, new[] { valueToSet });
				}
			}
		}
	}
