    public class MinimumAgeAttribute : RangeAttribute
    {
        public static string MinimumValue => ConfigurationManager.AppSettings["your key"];
        public static string MaxValue => ConfigurationManager.AppSettings["your key"];
        public CustomRangeAttribute(Type type):base(type,MaxValue , MinimumValue)
        {
        }
    }
