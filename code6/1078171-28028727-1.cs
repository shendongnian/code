    public class EnumHelpTextAttribute // Always postpend the word "Attribute" to an attribute class
                                       // The compiler cleans this suffix when you actually use the Attribute
        : OptionAttribute
    {
        public EnumHelpTextAttribute(LicenseType value)
            : base(string.Join(", ", Enum.GetName(typeof(LicenseType), value)))
        {
        }
    }
    // ...
    [EnumHelpText(LicenseType.Restricted)]  // Or some other value in LicenseType...
