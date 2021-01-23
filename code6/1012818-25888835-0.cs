    public class ExamVM
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public List<QuestionVM> Questions { get; set; }
    }
    public class QuestionVM
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public bool IsSelected { get; set; }
    }
