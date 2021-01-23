    public class AllChildBirtdaysMustBeLaterThanParent : PropertyValidator
    {
        public AllChildBirtdaysMustBeLaterThanParent()
            : base("Property {PropertyName} contains children born before their parent!")
        {
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var parent = context.ParentContext.InstanceToValidate as Parent;
            var list = context.PropertyValue as IList<Child>;
            if (list != null)
            {
                return ! (list.Any(c => parent.BirthDay > c.BirthDay));
            }
            return true;
        }
    }
