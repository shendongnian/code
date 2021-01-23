	var result = new List<QuestionAndAnswer>();
	
	for (int i = 0; i < projects.Prescreeners.Count; i++)
	{
		result.Add(new QuestionAndAnswer
		{
			Question = projects.Prescreeners[i],
			Answer   = projects.PrescreenerResponses[i],
		});
	}
