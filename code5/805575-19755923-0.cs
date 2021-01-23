    public class QuestionAndResponses
    {
       public PreScreener Question {get; set;}
       public IEnumerable <PreScreenerResponse> Responses {get; set;}
    }
    var questionAndResponses = new List<QuestionAndResponses>();
    foreach (var question in secondList)
    {
       questionAndResponses.Add(
                new QuestionAndResponses
               {
                  Question = question,
                  Responses = firstList.Where(f => f.QuestionId = question.QuestionId)
               });
    }
