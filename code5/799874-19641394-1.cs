    namespace Sample
    {
        using System.Globalization;
        using System.Linq;
        using System.Windows.Controls;
    
        public class ContainsValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                var result = MainWindowViewModel.CurrentInstance.Items.Any(x => x.ToLowerInvariant().Contains((value as string).ToLowerInvariant()));
                return new ValidationResult(result, "No Reason");
            }
        }
    }
