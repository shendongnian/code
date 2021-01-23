    public class LoginModule : NancyModule
    {
        public LoginModule()
        {
            Post["login"] = p =>
            {
                var name = Request.Form.name;
                var auth = Context.GetAuthenticationManager();
                var claims = new List<Claim> {new Claim(ClaimTypes.Name, name)};
                var id = new ClaimsIdentity(claims, Constants.AuthenticationType);
            
                auth.SignIn(id);
                
                Response.AsRedirect(p.RedirectUrl);
            };
         }
    }
