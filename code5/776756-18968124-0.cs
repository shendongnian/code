    public class FormDataTransformContainer
    {
      public string name { get; set; }
      public string description { get; set; }
      public IList<QuestionDataTransformContainer> questions { get; set; }
    }
    
    public class QuestionDataTransformContainer {
      public int type { get; set; }
      public string text { get; set; }
      public IList<AnswerDataTransformContainer> answers { get; set; }
      public IList<QuestionDataTransformContainer> children { get; set; }
    }
    
    public class AnswerDataTransformContainer {
      public string answer { get; set; }
      public int prerequisite { get; set; }
    }
