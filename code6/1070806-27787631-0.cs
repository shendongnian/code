    public class Response {
       public string QuestionId {get;set;}
       public string AnswerId {get;set;}
    }
    
    public class ExamViewModel {
        public int? TestId {get;set;}
        public List<Response> Responses {get;set;}
    }
    
    public ActionResult GradeTest(ExamViewModel viewModel)
    {
    ...
