		public static LineSpec LinestConst(IList<double> yValues, IList<double> xValues)
		{
			var yAvg = yValues.Sum() / yValues.Count;
			var xAvg = xValues.Sum() / xValues.Count;
			double upperSum = 0;
			double lowerSum = 0;
			for (var i = 0; i < yValues.Count; i++)
			{
				upperSum += (xValues[i] * yValues[i] );
				lowerSum += (xValues[i] * xValues[i] );
			}
			var m = upperSum / lowerSum;
			var b = 0;
			return new LineSpec() { Slope = m, Intercept = b };
		}
