    public class CasualMealChargeValidator : AbstractValidator<CasualMealCharge>
    {
        public CasualMealChargeValidator(CasualMealCharge CMC)
        {
            //RuleFor(x => x.BankName).NotEmpty().When(pm => pm.PaymentMode == "Cheque").WithMessage("Enter Bank.");
            RuleFor(x => x).Must(x => x.DN != CMC.DN || x.BF != CMC.BF || x.LN != CMC.LN).WithMessage("Not Saved - Meal charges are same as current charges.").WithName("CMFor");
        }
    }
