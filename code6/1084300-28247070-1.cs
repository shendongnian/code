	var rnd = new Random();
	Func<bool, string> getRespose = b =>
	{
		var choices = b
			? new [] { "Very good!", "Excellent!", "Nice work!", "Keep up the good work!", }
			: new [] { "Bad!", "V Bad!", "VV Bad!", "VVV Bad!", };
			
		return choices[rnd.Next(0, choices.Length)];
	};
