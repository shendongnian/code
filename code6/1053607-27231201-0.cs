    public class MyObjectValidator : AbstractValidator<MyObject>
        {
            public MyObjectValidator()
            {
                RuleFor(x => x.Name).NotEmpty().When(m => m.Type == 1).WithMessage("your msg");
                RuleFor(x => x.Name).Must(s => s.Length > 50).When(m => m.Type == 2).WithMessage("your msg");;
            }
    }
