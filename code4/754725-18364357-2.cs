    public class CityValidator: AbstractValidator<City>
    {
        public CityValidator()
        {
            this
                .RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Please name your city");
        }
    }
    
    public class CarValidator: AbstractValidator<Car>
    {
        public CityValidator()
        {
            this
                .RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("You should specify a name for your car");
        }
    }
    ...
