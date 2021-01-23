	var rnd = new Random();
	var choices = (string[])null;
	switch (correct)
	{
		case true:
			choices = new []
				{ "Very good!", "Excellent!", "Nice work!", "Keep up the good work!", };
			break;
		case false:
			choices = new [] { "Bad!", "V Bad!", "VV Bad!", "VVV Bad!", };
			break;
	}
	var response = choices[rnd.Next(0, choices.Length)];
