    public class RemoveAnswerValidator : BaseValidator
    {
        public RemoveAnswerValidator(RemoveAnswerValidatorParameters parms)
        {
            ...some code
        }
        public override bool Validates()
        {
            ...some code
        }
    }
    public class RemoveAnswerValidatorParameters
    {
        public int AnswerID { get; set; }
        public IAnswerRepository AnswerRepository { get; set; }
    }
