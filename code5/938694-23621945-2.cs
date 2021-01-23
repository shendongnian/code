    namespace Microsoft.Owin.Security
    {
      public static class AuthenticationManagerExtensions
      {
        public static ClaimsIdentity CreateTwoFactorRememberBrowserIdentity(
          this IAuthenticationManager manager, 
          string userId);
        public static Task<bool> TwoFactorBrowserRememberedAsync(
          this IAuthenticationManager manager, 
          string userId);
      }
    }
