	/// <summary>
	/// The swap.
	/// </summary>
	/// <param name="input">
	/// The input.
	/// </param>
	/// <returns>
	/// The <see cref="string"/>.
	/// </returns>
	/// <exception cref="ArgumentException">
	/// Can't swap input, which is null, empty or a white space!
	/// </exception>
	public static string Swap(this string input)
	{
		if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
		{
			throw new ArgumentException("Can't swap input, which is null, empty or a white space!");
		}
		var characters = input.ToCharArray();
		var returnValue = new StringBuilder();
		for (var i = 0; i < characters.Length; i++)
		{
			if (i % 2 != 0)
			{
				continue;
			}
			if ((i + 1) < characters.Length)
			{
				returnValue.Append(characters[i + 1]);
			}
			returnValue.Append(characters[i]);
		}
		return returnValue.ToString();
	}
