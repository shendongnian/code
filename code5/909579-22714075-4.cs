		public static void SetIfChanged<T>(T value, T newValue, Action<T> action)
		{
			if (object.Equals(value, newValue) == false)
			{
				action(value);
			}
		}
