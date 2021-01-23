    public interface IModelValidator
    {
    }
    //example of a validator class
    public class MyModelValidator : AbstractValidator<MyModel>, IModelValidator
    {
        public MyModelValidator ()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.yourField)
                .NotNull()
                .NotEmpty()
                .WithMessage("You need to enter yourField");
        }
    }
    void RegisterValidators(IUnityContainer container)
    {
       var type = typeof(IValidator<>);
       var validators = AssemblyScanner.FindValidatorsInAssemblyContaining<IModelValidator>();
    
       validators.ForEach(validator => container.RegisterType(validator.InterfaceType, validator.ValidatorType));
    }
