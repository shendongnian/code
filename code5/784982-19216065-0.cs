    public class CustomRequiredAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            string str = value as string;
            if (!string.IsNullOrWhiteSpace(str))
            {
                return true;
            }
            return false;
        }
    }
