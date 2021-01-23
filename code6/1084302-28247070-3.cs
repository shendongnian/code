	var rnd = new Random();
	Func<bool, string> getRespose = b =>
	{
		var choices = (string[])null;
		switch (b)
		{
			case true:
				choices = new []
					{ "Very good!", "Excellent!", "Nice work!", "Keep up the good work!", };
				break;
			case false:
				choices = new []
					{ "Bad!", "V Bad!", "VV Bad!", "VVV Bad!", };
				break;
		}
		
		return choices[rnd.Next(0, choices.Length)];
	};
	var response = getRespose(correct);
