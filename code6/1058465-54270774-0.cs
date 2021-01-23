    public class MultiCulturalControlValidator : AbstractValidator<TitleMultiCulturalControlProperty>
    {
        public MultiCulturalControlValidator()
        {
             RuleFor(x => x.EnglishValue).NotEmpty().WithMessage(x => string.Format("test error {0}",  x.DisplayName));
        }
    }
