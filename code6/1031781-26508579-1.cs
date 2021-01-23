    public class StrongPasswordValidator : IIdentityValidator<string>
    {
        public int MinimumLength { get; set; }
        public int MaximumLength { get; set; }
        private readonly MyCustomObjectType _myCustomObject;
    
        public void CustomPasswordValidator(int minimumLength, int maximumLength, 
                                            MyCustomObjectType myCustomObject)
        {
            // guard clause
            if(myCustomObject == null)
            {
               throw new ArgumentExpcetion("myCustomObject was not provided.");
            }
            _myCustomObject = myCustomObject;
            this.MinimumLength = minimumLength;
            this.MaximumLength = maximumLength;
        }
    
        public Task<IdentityResult> ValidateAsync(string item)
        {
            // use _myCustomObject here
            if (item.Length < MinimumLength)
            {
                return Task.FromResult(IdentityResult.Failed("Password must be a minimum of " + MinimumLength + " characters."));
            }
            if (item.Length > MaximumLength)
            {
                return Task.FromResult(IdentityResult.Failed("Password must be a maximum of " + MaximumLength + " characters."));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
