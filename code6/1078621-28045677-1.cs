    List<string> list = new List<string>();
    model.QuestionSetList = new  List<string>();
    for (int i = 0; i < response.QuestionsInfoList.Count(); i++)
    {
         list.Add(response.QuestionSetInfo.QuestionsInfoList[i].Question);
         foreach (AnswerSetContract answerSetContract in response.QuestionsInfoList[i].AnswersInfoList)
         {
             model.QuestionSetList.Add(answerSetContract.AnswerText);
         }
    }
