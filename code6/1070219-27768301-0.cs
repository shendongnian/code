		public static void Shuffle<T>(IList<T> arr, Random rnd)
		{
			for (var i = 0; i < arr.Count; i++)
			{
				var j = rnd.Next(i, arr.Count);
				var tmp = arr[i];
				arr[i] = arr[j];
				arr[j] = tmp;
			}
		}
