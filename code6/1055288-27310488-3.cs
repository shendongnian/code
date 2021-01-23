    public class QuestionVM
    {
      public int ID { get; set; }
      public string Text { get; set; }
      public int SelectedAnswer { get; set; }
      public List<AnswerVM> AnswerList { get; set; }
    }
    public class AnswerVM
    {
      public int ID { get; set; }
      public string Text { get; set; }   
    }
