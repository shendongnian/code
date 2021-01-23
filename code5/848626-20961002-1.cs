    public class CustomPasswordValidator : IIdentityValidator<string>
    {
    
        public int MinimumLength { get; private set; }
        public int MaximumLength { get; private set; }
    
        public CustomPasswordValidator(int minimumLength, int maximumLength)
        {
            this.MinimumLength = minimumLength;
            this.MaximumLength = maximumLength;
        }
        public Task<IdentityResult> ValidateAsync(string item)
        {
            if (!string.IsNullOrWhiteSpace(item) 
                && item.Trim().Length >= MinimumLength 
                && item.Trim().Length <= MaximumLength)
                return Task.FromResult(IdentityResult.Success);
            else return Task.FromResult(IdentityResult.Failed("Password did not meet requrements."));
    
        }
    }
