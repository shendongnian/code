		public static void SetIfChanged<T>(ref T prop, T value)
		{
			if (object.Equals(prop, value) == false)
			{
				prop = value;
			}
		}
