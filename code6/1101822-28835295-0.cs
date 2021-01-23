    public class CustomRequiredAttribute : RequiredAttribute
    {
        public override IsValid(object val, ValidationContext context)
        {
            if(SomeConditionisValid())
                 return base.IsValid(val, context);
            else
                 return true; // the field is valid (e.g not required)
        }
    }
