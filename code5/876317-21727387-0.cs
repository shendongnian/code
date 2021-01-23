    public class MyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int temp;
            if (!Int32.TryParse(value.ToString(), out temp))
                return false;
            if (temp == 0)
                return false;
            return true;
        }
    }
