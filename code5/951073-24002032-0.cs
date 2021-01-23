    public class QuestionAnswer {
        public string Question {get;set;}
        public string Answer {get;set;}
    }
    ...
    var pairs = conn1.Query<QuestionAnswer>("select Question, Answer from MyTable")
           .ToList();
