	static int[] IntPercents(double[] values)
	{
		int[] results = new int[values.Length];
		double error = 0;
		for (int i = 0; i < values.Length; i++)
		{
			double val = values[i];
			int percent = (int)Math.Round((val + error) * 100);
			error += val - (percent / 100.0);
			if (Math.Abs(error) >= 0.005)
			{
				int sign = Math.Sign(error);
				percent += sign;
				error -= sign / 100.0;
			}
			results[i] = percent;
		}
		return results;
	}
