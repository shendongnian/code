    public class CookieAuthenticationProviderWrapper : ICookieAuthenticationProvider
    {
        private CookieAuthenticationProvider _cookieAuthenticationProvider;
        public CookieAuthenticationProviderWrapper(CookieAuthenticationProvider cookieAuthenticationProvider)
        {
            _cookieAuthenticationProvider = cookieAuthenticationProvider;
            OnApplyingRedirect = context => { };
            OnRedirectApplied = context => { };
        }
        public Action<CookieApplyRedirectContext> OnRedirectApplied { get; set; }
        public Action<CookieApplyRedirectContext> OnApplyingRedirect { get; set; }
        public void ApplyRedirect(CookieApplyRedirectContext context)
        {
            OnApplyingRedirect.Invoke(context);
            _cookieAuthenticationProvider.ApplyRedirect(context);
            OnRedirectApplied.Invoke(context);
        }
        public void ResponseSignIn(CookieResponseSignInContext context)
        {
            _cookieAuthenticationProvider.ResponseSignIn(context);
        }
        public System.Threading.Tasks.Task ValidateIdentity(CookieValidateIdentityContext context)
        {
            return _cookieAuthenticationProvider.ValidateIdentity(context);
        }
    }
