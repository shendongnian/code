    public class MyStringLengthAttribute : StringLengthAttribute
    {
        public MyStringLengthAttribute(int maximumLength)
            : base(maximumLength)
        {
        }
    
        public override bool IsValid(object value)
        {
            string val = Convert.ToString(value);
            if (val.Length < base.MinimumLength)
                base.ErrorMessage = "Minimum length should be 3";
            if (val.Length > base.MaximumLength)
                base.ErrorMessage = "Maximum length should be 6";
            return base.IsValid(value);
        }
    }
    public class MyViewModel
    {
        [MyStringLength(6, MinimumLength = 3)]
        public String MyProperty { get; set; }
    }
