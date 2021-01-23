    `public void SignOut()
        {
            IOwinContext context = _context.Request.GetOwinContext();
            IAuthenticationManager authenticationManager = context.Authentication;
            authenticationManager.SignOut(AuthenticationType);
        }
    `
