    public class SoftwareOrderValidator : AbstractValidator<SoftwareOrder>
    {
       public SoftwareOrderValidator()
       {
          RuleForEach(order => order.SoftwareItem)
             .Must(BeCompatibleWithSystem)
             .WithMessage("Software is incompatible with system");
       }
       private bool BeCompatibleWithSystem(SoftwareOrder order, SoftwareItem item)
       {
          if (item.Selected)
             return (order.IsLegacySystem == item.IsLegacySoftware);
          else
             return true;
       }
    }
