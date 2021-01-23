    public class AnswerVM
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public bool IsSelected { get; set; }
    }
    public class MyVM
    {
      public bool IsMultipleChoice { get; set; }
      public List<AnswerVM> Answers { get; set; }
      public int? SelectedAnswer { get; set ; } // for single choice
    }
