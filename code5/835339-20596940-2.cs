    public class SomeService : Service
    {
        // Validator with be injected, you need to registered it in the IoC container.
        public IValidator<WithSession<UserSettingsRequest>> { get; set; }
        public object Post(UserSettingsRequest request) // Match to your own request
        {
            // Combine the request with the current session instance
            var requestWithSession = new WithSession<UserSettingsRequest> {
                Session = this.Session,
                Object = request
            };
            // Validate the request
            ValidationResult result = this.Validator.Validate(requestWithSession);
            if(!result.IsValid)
            {
                throw result.ToException();
            }
            // Request is valid
            // ... more logic here
            return result;
        }
    }
