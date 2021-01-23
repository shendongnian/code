    public class CustomPasswordValidator : IIdentityValidator<string>
    {
        public int RequiredLength { get; set; }
        public CustomPasswordValidator(int length) {
            RequiredLength = length;
        }
        /* 
         * logic to validate password: I am using regex to count how many 
         * types of characters exists in the password
         */
        public Task<IdentityResult> ValidateAsync(string password) {
            if (String.IsNullOrEmpty(password) || password.Length < RequiredLength)
            {
                return Task.FromResult(IdentityResult.Failed(
                    String.Format("Password should be at least {0} characters", RequiredLength)));
            }
            int counter = 0;
            List<string> patterns = new List<string>();
            patterns.Add(@"[a-z]");                                          // lowercase
            patterns.Add(@"[A-Z]");                                          // uppercase
            patterns.Add(@"[0-9]");                                          // digits
            patterns.Add(@"[!@#$%^&*\(\)_\+\-\={}<>,\.\|""'~`:;\\?\/\[\]]"); // special symbols
            // count type of different chars in password
            foreach (string p in patterns)
            {
                if (Regex.IsMatch(password, p)) {
                    counter++;
                }
            }
            if (counter < 2)
            {
                return Task.FromResult(IdentityResult.Failed(
                    "Please use characters from at least two of these groups: lowercase, uppercase, digit, special"));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
