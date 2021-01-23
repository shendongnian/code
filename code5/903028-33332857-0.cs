        public virtual async Task<IdentityResult> UpdatePassword(ApplicationUser user, string newPassword)
        {
            var passwordStore = Store as IUserPasswordStore<ApplicationUser, string>;
            
            if (passwordStore == null)
                throw new Exception("UserManager store does not implement IUserPasswordStore");
            var result = await base.UpdatePassword(passwordStore, user, newPassword);
            if (result.Succeeded)
                result = await base.UpdateAsync(user);
            return result;
        }
