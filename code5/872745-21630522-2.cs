    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public sealed class AddressRequiredAttribute : RequiredAttribute, IClientValidatable
    {
        public AddressRequiredAttribute()
            : base()
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Type addresType = typeof(AddressModel);
            if (context.ObjectType == addresType || context.ObjectType.BaseType == addresType)
            {
                AddressModel baseModel = (AddressModel)context.ObjectInstance;
                if (baseModel != null && baseModel.AddressIsRequired)
                {
                    return base.IsValid(value, context);
                }
            }
            return ValidationResult.Success;
        }
    }
