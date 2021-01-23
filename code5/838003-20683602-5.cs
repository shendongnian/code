    public class InitialsMustBeAvailableAttribute : ValidationAttribute
    {
        [Dependency]
        public IUserService UserService { get; set; }
        public override bool IsValid(object value)
        {
            return UserService.AreInitialsAvailable((string)value);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userService = (IUserService)validationContext.GetService(typeof(IUserService));
            if (userService != null)
            {
                if (userService.AreInitialsAvailable((string) value))
                {
                    return null;
                }
            }
            return new ValidationResult("Initals must be unique!");
        }
    }
