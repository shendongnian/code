    public string GenerateNumber(string input)
	{
		if (string.IsNullOrWhiteSpace(input))
		{
			throw new ArgumentNullException("input");
		}
		Random rand = new Random();
		StringBuilder builder = new StringBuilder();
		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] == '-')
			{
				builder.Append("-");
			}
			else
			{
				builder.Append(rand.Next(0, 9).ToString());
			}
		}
		return builder.ToString();
	}
