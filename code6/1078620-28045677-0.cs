    using System.Linq;
    
    List<string> list = new List<string>();
    model.QuestionSetList = new  List<string>();
    for (int i = 0; i < response.QuestionsInfoList.Count(); i++)
    {
         list.Add(response.QuestionSetInfo.QuestionsInfoList[i].Question);
         foreach (AnswerSetContract answerSetContract in response.QuestionsInfoList[i].AnswersInfoList)
         {
             list.Add(answerSetContract.AnswerText);
         }
         model.QuestionSetList.Concat(list);
    }
