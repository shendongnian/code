    using FluentValidation;
    using Project.Models.Entities;
    namespace Project.Models.Validators
    {
        public class PostValidator : AbstractValidator<Post>
        {
            public PostValidator()
            {
                RuleFor(p => p.Title)
                    .NotEmpty()
                    .Length(1, 200);
                RuleFor(p => p.Body)
                    .NotEmpty();
            }
        }
    }
