    public class EnumHelpTextAttribute
    {
        public EnumHelpTextAttribute(LicenseType value)
            : base(string.Join(", ", Enum.GetName(typeof(LicenseType), value)))
        {
        }
    }
    // ...
    [EnumHelpText(LicenseType.Restricted)]  // Or some other value in LicenseType...
