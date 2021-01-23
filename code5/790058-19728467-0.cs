    public static void Fill(object[] array, int index, int count, object value)
		{
			for (int i = index; i < index + count; i++)
			{
				array[i] = value;
			}
		}
