     ....
     public Task<bool> GetTwoFactorEnabledAsync(User user)
     {
         return Task.FromResult(false);
     }
     public Task SetTwoFactorEnabledAsync(User user, bool enabled)
     {
         throw new NotImplementedException();
     }
