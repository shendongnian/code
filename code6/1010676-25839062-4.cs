    public class QuestionVM
    {
      public int ID { get; set; } // for binding
      public string Text { get; set; }
      [Required]
      public int? SelectedAnswer { get; set; } // for binding
      public IEnumerable<Answer> PossibleAnswers { get; set; }
    }
    public class RegistrationViewModel : RegisterExternalLoginModel
    {
      public RegistrationViewModel()
      {
        Questions = new List<QuestionVM>();
      }
      //...etc...
      public List<QuestionVM> Questions { get; set; }
    }
