    public static class MyExtensions
	{
		public static double? GetNearestValue (this IDictionary<double, long> dictionary, double value)
		{
			if (dictionary == null || dictionary.Count == 0)
				return null;
			double? nearestDiffValue = null;
			double? nearestValue = null;
			foreach (var item in dictionary) {
				double currentDiff = Math.Abs (item.Key - value);
				if (nearestDiffValue == null || currentDiff < nearestDiffValue.Value) {
					nearestDiffValue = currentDiff;
					nearestValue = item.Value;
				}
			}
			return nearestValue;
		}
	}
