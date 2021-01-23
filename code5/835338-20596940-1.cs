    // This class allows you to add pass in your session and your object
    public class WithSession<T>
    {
        public UserSession Session { get; set; }
        public T Object { get; set; }
    }
    public interface IUserAccessValidator
    {
        bool ValidUser(UserSession session);
    }
    public class UserAccessValidator : IUserAccessValidator
    {
        public bool ValidUser(UserSession session)
        {
            // Your validation logic here
            // session.UserId
            return true;
        }
    }
    public class UserSettingsValidator : AbstractValidator<WithSession<UserSettingsRequest>>
    {
        public IUserAccessValidator UserAccessValidator { get; set; }
        public UserSettingsValidator()
        {
            // Notice check now uses .Object to access the object within
            RuleFor(x => x.Object.UserId)
                .SetValidator(new PositiveIntegerValidator());
            // Custom User Access Validator check, passing the session
            RuleFor(x => x.Session).Must(x => UserAccessValidator.ValidUser(x)); 
        }
    }
