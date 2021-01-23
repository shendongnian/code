    [Authorize]
    public class RefreshTokenController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ReissueToken()
        {
            // just use old identity
            var identity = ((ClaimsPrincipal)User).Identity as ClaimsIdentity;
    
            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            DateTimeOffset currentUtc = new SystemClock().UtcNow;
    
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.AddMinutes(30);
    
            string token = Startup.OAuthBearerAuthOptions.AccessTokenFormat.Protect(ticket);
    
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(new
                {
                    accessToken = token,
                    expiresIn = (int)((ticket.Properties.ExpiresUtc.Value - ticket.Properties.IssuedUtc.Value).TotalSeconds),
                }, Configuration.Formatters.JsonFormatter)
            };
        }
    }
