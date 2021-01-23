     public AuthenticateService AuthService
            {
                get
                {
                    var _as = HostContext.ResolveService<AuthenticateService>(base.HttpContext);
                    return _as;
                }
            }
