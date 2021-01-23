	public class test
	{
		public static void Main()
		{
			var bundleSizes = new List<int> { 46, 25, 12, 4, 3 };
			var bundles = new Dictionary<int, int>();
			bundleSizes.ForEach(e => bundles.Add(e, 0));
			var quantity = 30;
			var bundleResults = Begin(bundleSizes, quantity);
			Output(bundleSizes, quantity, bundleResults);
			quantity = 17;
			bundleResults = Begin(bundleSizes, quantity);
			Output(bundleSizes, quantity, bundleResults);
			quantity = 47;
			bundleResults = Begin(bundleSizes, quantity);
			Output(bundleSizes, quantity, bundleResults);
			quantity = 5;
			bundleResults = Begin(bundleSizes, quantity);
			Output(bundleSizes, quantity, bundleResults);
			Console.Read();
		}
		static void Output(List<int> bundleSizes, int quantity, Dictionary<int, int> bundleResults)
		{
			Console.WriteLine("Bundle Sizes: {0}", string.Join(",", bundleSizes));
			Console.WriteLine("Quantity: {0}", quantity);
			Console.WriteLine("Returned Value: {0}", bundleResults == null ? "null" : bundleResults.Aggregate("", (keyString, pair) => keyString + pair.Key + ":" + pair.Value + ","));
		}
		static Dictionary<int, int> Begin(List<int> bundleSizes, int quantity)
		{
			var bundleCombinations = GetCombination(bundleSizes);
			var tempBundleSizes = new List<Dictionary<int, int>>();
			foreach (var bundleCombination in bundleCombinations)
			{
				var tempBundleSize = new Dictionary<int, int>();
				bundleCombination.ForEach(e => tempBundleSize.Add(e, 0));
				var results = Bundle(bundleCombination, quantity);
				if (results == null)
					continue;
				foreach (var result in results)
				{
					tempBundleSize[result.Key] = result.Value;
				}
				tempBundleSizes.Add(tempBundleSize);
			}
			var longest = tempBundleSizes.OrderByDescending(x => x.Count).FirstOrDefault();
			return longest;
		}
		static List<List<int>> GetCombination(List<int> list)
		{
			var retValue = new List<List<int>>();
			var count = Math.Pow(2, list.Count);
			for (var i = 1; i <= count - 1; i++)
			{
				var retList = new List<int>();
				var str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
				for (var j = 0; j < str.Length; j++)
				{
					if (str[j] == '1')
					{
						retList.Add(list[j]);
					}
				}
				retValue.Add(retList);
			}
			return retValue;
		}
		static Dictionary<int, int> Bundle(List<int> bundleSizes, int quantity)
		{
			var bundleQuantities = new Dictionary<int, int>();
			bundleSizes.ForEach(delegate(int k)
			{
				if (k <= quantity)
					bundleQuantities.Add(k, 0);
			});
			return bundleQuantities.Count == 0 ? null : RecurseBundles(quantity, bundleQuantities.Keys.ToList(), bundleQuantities);
		}
		static Dictionary<int, int> RecurseBundles(int quantity, List<int> bundleSizes, Dictionary<int, int> bundleQuantities)
		{
			var bundleSize = bundleSizes.First();
			var bundles = (int)Math.Floor((double)quantity / bundleSize);
			var remainingQuantity = quantity % bundleSize;
			bundleQuantities[bundleSize] = bundles;
			var remainingBundles = bundleSizes.Skip(1).ToList();
			if (!remainingBundles.Any() && remainingQuantity > 0)
				bundleQuantities = null;
			if (remainingBundles.Any())
				bundleQuantities = RecurseBundles(remainingQuantity, remainingBundles, bundleQuantities);
			return bundleQuantities;
		}
	}
