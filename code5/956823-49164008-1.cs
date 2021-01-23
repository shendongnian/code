    public override void OnAuthorization(HttpActionContext actionContext)
    {
                if (Roles == null)
                    HandleUnauthorizedRequest(actionContext);
                else
                {
                    ClaimsIdentity claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
                    string _role = claimsIdentity.FindFirst(ClaimTypes.Role).Value;
                    bool isAuthorize = Roles.Any(role => role == _role);
                    
                    if(!isAuthorize)
                        HandleUnauthorizedRequest(actionContext);
                }
            }
