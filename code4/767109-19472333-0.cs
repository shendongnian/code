    public class ResponseViewModel : IValidatableObject
    {
        public QuestionViewModel Question { get; set; }
        public string Answer { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Question.IsRequired && string.IsNullOrEmpty(Answer))
            {
                yield return new ValidationResult("An answer is required.");
            }
        }
    }
