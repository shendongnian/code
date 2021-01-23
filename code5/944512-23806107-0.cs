    namespace JensB.Tools.CustomAttributes
    {
        public class IsDateOk: ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null) return false;
                if (value.GetType() != typeof(DateTime)) throw new InvalidOperationException("can only be used on DateTime properties.");
                bool isValid = // do validation here
    
                return isValid;
            }
        }
    }
