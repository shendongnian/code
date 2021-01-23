    public class WhiteSpaceCheckerAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var strValue = value as string;
            return strValue != null && !strValue.Contains(" ");
        }
    }
