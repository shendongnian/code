        public CustomPasswordValidator(int length) {
            RequiredLength = length;
        }
        public Task<IdentityResult> ValidateAsync(string item) {
            if (String.IsNullOrEmpty(item) || item.Length < RequiredLength)
            {
                return Task.FromResult(IdentityResult.Failed(
                    String.Format("Password should be at least {0} characters", RequiredLength)));
            }
            int counter = 0;
            List<string> patterns = new List<string>();
            patterns.Add(@"[a-z]");         // lowercase
            patterns.Add(@"[A-Z]");         // uppercase
            patterns.Add(@"[0-9]");         // digits
            patterns.Add(@"[!@#$%^&*\(\)_\+\-\={}<>,\.\|""'~`:;\\?\/\[\]]");    // special symbols
            foreach (string p in patterns)
            {
                if (Regex.IsMatch(item, p)) {
                    counter++;
                }
            }
            if (counter < 2)
            {
                return Task.FromResult(IdentityResult.Failed(
                    "Please use characters from at least two of these groups: lowercase, uppercase, digit, secial"));
            }
            return Task.FromResult(IdentityResult.Success);
        }
