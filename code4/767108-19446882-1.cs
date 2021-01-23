    public class ResponseViewModel {
    
        public QuestionViewModel Question { get; set; }
    
        [RequiredIf("Question.IsRequired", true, "This question is required.")]
        public string Answer { get; set; }
    }
