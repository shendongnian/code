    public class UniqueLoginAttribute : ValidationAttribute
    {
        public UniqueLoginAttribute(Type managerType)
        {
            this.ManagerType = managerType;
        }
        public Type ManagerType { get; private set; }
        protected override ValidationResult IsValid(object value,
              ValidationContext validationContext)
        {
            IManage manager = Activator.CreateInstance(this.ManagerType) as IManage;
            return manager.Validate(value);
        }
    }
