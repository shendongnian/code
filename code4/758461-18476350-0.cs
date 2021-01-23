    sealed public class MultipleOf10Attribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ((int)value) % 10 == 0;
        }
    }
