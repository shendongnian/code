    public class Recipient
    {
        [RegularExpression(Helper.DefaultEmailValidationPattern, ErrorMessageResourceName = "InvalidValue", ErrorMessageResourceType = typeof(i18n))]
        public string EmailAddress { get; set; }
    }
