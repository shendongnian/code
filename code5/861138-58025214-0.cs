    public class ParentModel : IValidatableObject
    {
        //.....
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            foreach (var child in Children.Where(child => child.DateOfBirth.Date < EffectiveDate.AddYears(-1).Date || child.DateOfBirth.Date > EffectiveDate.Date))
            {
                result.Add(new ValidationResult($"The date of birth {child.DateOfBirth} of child {child.Name} is not between now and a year ago."));
            }
            return result;
        }
    }
