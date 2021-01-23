    // Add this private variable
    private IAuthenticationManager _authnManager;
    // Modified this from private to public and add the setter
    public IAuthenticationManager AuthenticationManager
    {
        get
        {
            if (_authnManager == null)
                _authnManager = HttpContext.GetOwinContext().Authentication;
            return _authnManager;
        }
        set { _authnManager = value; }
    }
