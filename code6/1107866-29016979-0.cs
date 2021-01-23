        public Task<int> GetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }
        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult<bool>(false);
        }
        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            throw new NotImplementedException();
        }
        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }
        public Task ResetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }
        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }
        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }
        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult<bool>(false);
        }
        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }
