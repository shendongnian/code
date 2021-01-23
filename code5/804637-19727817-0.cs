		public static int Count(Array pValues)
		{
			int count = 0;
			foreach(object value in pValues)
			{
				if(value.GetType().IsArray)
				{
					count += Count((Array) value);
				}
				else
				{
					count ++;
				}
			}
			return count;
		}
