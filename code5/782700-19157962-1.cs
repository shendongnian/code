      public class InvoiceDetailsWorksheetRowValidator : AbstractValidator<IXLRow>
      {
          public InvoiceDetailsWorksheetRowValidator()
          {
            RuleFor(x => x.Cell("B"))
                .Must(BeAnInt).WithMessage("ClaimantID column value is not a number.")
                .OverridePropertyName("ClaimantIDColumn");
            RuleFor(x => x.Cell("E"))
                .Must(BeAnInt).WithMessage("InvoiceNumber column value is not a number.")
                .OverridePropertyName("ClaimantIDColumn");
          }
          private bool BeAnInt(IXLCell cellToCheck)
          {
            int result;
            var successful = cellToCheck.TryGetValue(out result);
            return successful;
          }
      }
