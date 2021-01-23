	var input =  new StringBuilder(" th@ere's! ");
	
	Func<char, bool> isDigitOrLetter = ch => char.IsLetter(ch) || char.IsDigit(ch);
	for (int i = 1; i < input.Length - 1; i++)
	{
		if(!isDigitOrLetter(input[i]))
		{
			if(!isDigitOrLetter(input[i-1]) || !isDigitOrLetter(input[i+1]))
			{
				input.Remove(i, 1);
			}
		}
	}
	Console.WriteLine(word); //prints " th@ere's "
