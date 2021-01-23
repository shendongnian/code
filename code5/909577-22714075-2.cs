		public static void SetIfChanged<T>(T value, Action<T> newValue)
		{
			if (object.Equals(value, newValue) == false)
			{
				newValue(value);
			}
		}
