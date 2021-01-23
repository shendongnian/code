	static int[] ToIntPercents(double[] values)
	{
		int[] results = new int[values.Length];
		double error = 0;
		for (int i = 0; i < values.Length; i++)
		{
			double val = values[i] * 100;
			int percent = (int)Math.Round(val + error);
			error += val - percent;
			if (Math.Abs(error) >= 0.5)
			{
				int sign = Math.Sign(error);
				percent += sign;
				error -= sign;
			}
			results[i] = percent;
		}
		return results;
	}
