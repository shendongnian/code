    public class SomeBusinessCommand
    {
        public string PropertyX { get; set; }
    }
    
    public class SomeBusinessValidator : AbstractValidator<SomeBusinessCommand>
    {
        public SomeBusinessValidator()
        {
            RuleFor(x => x.Property1).NotEmpty().MustMeetSomeBusinessRequirement();
        }
    }
    public class SomeViewModel // assume this maps to SomeBusinessCommand
    {
        public string PropertyX { get; set; }
    }
    
    public class SomeViewValidator : AbstractValidator<SomeViewModel>
    {
        public SomeViewValidator()
        {
            RuleFor(x => x.Property1).NotEmpty().MustMeetSomeBusinessRequirement();
        }
    }
