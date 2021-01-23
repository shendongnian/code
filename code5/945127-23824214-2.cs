    public List<Tuple<int, int>> GetPeaks(int[] values)
	{
		List<Tuple<int, int>> results = new List<Tuple<int, int>>();
		List<int> curInterval = new List<int>();
		bool decreasing = false;
		for (int i = 0; i < values.Length; i++)
		{
			if (curInterval.Count > 0)
			{
				if (values[i] < curInterval.Last() && !decreasing)
				{
					results.Add(new Tuple<int, int>(i - 1, curInterval.Last()));
					curInterval.Clear();
					decreasing = true;
				}
				else if (values[i] >= curInterval.Last() && decreasing)
				{
					decreasing = false;
				}
			}
			curInterval.Add(values[i]);
		}
		return results;
	}
