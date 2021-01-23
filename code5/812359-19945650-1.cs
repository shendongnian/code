    //StringBuilder allows you to modify string in place
	var input =  new StringBuilder(" th@ere's! ");
	Func<char, bool> isSpecialChar = ch => !(char.IsLetter(ch) || char.IsDigit(ch));
	
	for (int i = 1; i < input.Length - 1; i++)
	{
		//if current character is a special symbol
		if(isSpecialChar(input[i])) 
		{
			//if previous or next character are special symbols
			if(isSpecialChar(input[i-1]) || isSpecialChar(input[i+1]))
			{
				//remove that character
				input.Remove(i, 1);
			}
		}
	}
	Console.WriteLine(input.ToString()); //prints " th@ere's "
