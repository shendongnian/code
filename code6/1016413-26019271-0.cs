		public static IEnumerable<T[]> CombinationsAnyLength<T>(params T[] values)
		{
			for(var i = 0; i < (1 << values.Length); i++)
			{
				var result = new List<T>();
				for(var j = 0; j < values.Length; j++)
				{
					if(((1 << j) & i) != 0)
					{
						result.Add(values[j]);
					}
				}
				yield return result.ToArray();
			}
		}
