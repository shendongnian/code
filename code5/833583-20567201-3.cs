    public class ValidateTestMq
    {
        public int Id { get; set; }
    }
    public class ValidateTestMqResponse
    {
        public int CorrelationId { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
    public class ValidateTestMqValidator : AbstractValidator<ValidateTestMq>
    {
        public ValidateTestMqValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithErrorCode("PositiveIntegersOnly");
        }
    }
