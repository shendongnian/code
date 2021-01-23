    public class MyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int temp;
            if (!Int32.TryParse(value.ToString(), out temp))
                return false;
            return true;
        }
    }
