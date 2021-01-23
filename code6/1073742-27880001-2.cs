	public void GetQuestion()
	{
		NumQuestionList = QuestionList.Count;
		RandomQuestion = QuestionList[RandomNum.Next(0, NumQuestionList)];
		
		// Once question has been selected, remove it from the list.
		// This way it will not be selected again.
		QuestionList.Remove(RandomQuestion)
	}
