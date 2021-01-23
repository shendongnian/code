    public class SoftwareOrderValidator : AbstractValidator<SoftwareOrder>
    {
       private bool _isLegacySystem;
       public SoftwareOrderValidator()
       {
          RuleFor(order => order.IsLegacySystem)
             .Must(SetUpSoftwareItemValidatorConstructorArg);
          RuleForEach(order => order.SoftwareItem)
             .SetValidator(new SoftwareItemValidator(_isLegacySystem));
       }
       private bool SetUpSoftwareItemValidatorConstructorArg(bool isLegacySystem)
       {
          _isLegacySystem = isLegacySystem;
          return true;
       }
    }
    public class SoftwareItemValidator : AbstractValidator<SoftwareItem>
    {
       public SoftwareItemValidator(bool IsLegacySystem)
       {
         When(item => item.Selected, () =>
         {
            RuleFor(item => item.IsLegacySoftware)
                .Equal(IsLegacySystem).WithMessage("Software is incompatible with system");
         });
       }
    }
