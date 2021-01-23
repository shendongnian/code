    public class QuestionVM
    {
      public int ID { get; set; } // for binding
      public string Text { get; set; }
      [Required]
      public int? SelectedAnswer { get; set; } // for binding
      public IEnumerable<AnswerVM> PossibleAnswers { get; set; }
    }
    public class SubjectVM
    {
      public int? ID { get; set; }
      [DisplayFormat(NullDisplayText = "General")]
      public string Name { get; set; }
      public List<QuestionVM> Questions { get; set; }
    }
    public class AnswerVM
    {
      public int ID { get; set; }
      public string Text { get; set; }
    }
    public class StudentVM
    {
      public int ID { get; set; }
      public string Name { get; set; }
      // plus any other properties of student that you want to display in the view
      public List<SubjectVM> Subjects { get; set; }
    }
