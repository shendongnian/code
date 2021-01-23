    public class MyUserValidator : IIdentityValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(User item)
        {
            ...
        }
    }
