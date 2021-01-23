    /// <summary>
    /// The B2C token handler for handling dynamically loaded B2C tenants.
    /// </summary>
    protected B2CTokenHandler TokenHandler = new B2CTokenHandler();
    /// <summary>
    /// Setup the OAuth authentication. We use the database to retrieve the available B2C tenants.
    /// </summary>
    /// <param name="app">The application builder object</param>
    public AuthOAuth2(IAppBuilder app) {
        // get Active Directory endpoint
        AadInstance = ConfigurationManager.AppSettings["b2c:AadInstance"];
        // get the B2C policy list used by API1
        PolicyIdList = ConfigurationManager.AppSettings["b2c:PolicyIdList"].Split(',').Select(p => p.Trim()).ToList();
        TokenValidationParameters tvps = new TokenValidationParameters {
            NameClaimType = "http://schemas.microsoft.com/identity/claims/objectidentifier"
        };
        // create a access token format 
        JwtFormat jwtFormat = new JwtFormat(tvps);
        // add our custom token handler which will provide token validation parameters per tenant
        jwtFormat.TokenHandler = TokenHandler;
        // wire OAuth authentication for tenants
        app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions {
            // the security token provider handles Azure AD B2C metadata & signing keys from the OpenIDConnect metadata endpoint
            AccessTokenFormat = jwtFormat,
            Provider = new OAuthBearerAuthenticationProvider() {
                OnValidateIdentity = async (context) => await OAuthValidateIdentity(context)
            }
        });
        // load initial OAuth authentication tenants
        LoadAuthentication();
    }
    /// <summary>
    /// Load the OAuth authentication tenants. We maintain a local hash map of those tenants during
    /// processing so we can track those tenants no longer in use.
    /// </summary>
    protected override void LoadAuthentication() {
        AuthProcessing authProcessing = new AuthProcessing();
        List<B2CAuthTenant> authTenantList = new List<B2CAuthTenant>();
        // add all tenants for authentication
        foreach (AuthTenantApp authTenantApp in authProcessing.GetAuthTenantsByAppId("API1")) {
            // create a B2C authentication tenant per policy. Note that the policy may not exist, and
            // this will be handled by the B2C token handler at configuration load time below
            foreach (string policyId in PolicyIdList) {
                authTenantList.Add(new B2CAuthTenant {
                    Audience = authTenantApp.ClientId,
                    PolicyId = policyId,
                    TenantName = authTenantApp.Tenant
                });
            }
        }
        // and load the token handler with the B2C authentication tenants
        TokenHandler.LoadConfiguration(AadInstance, authTenantList);
        // we must update the CORS origins
        string origins = string.Join(",", authProcessing.GetAuthTenantAuthoritiesByAppId("API1").Select(a => a.AuthorityUri));
        // note some browsers do not support wildcard for exposed headers - there specific needed. See
        //
        // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Access-Control-Expose-Headers#Browser_compatibility
        EnableCorsAttribute enableCors = new EnableCorsAttribute(origins, "*", "*", "Content-Disposition");
        enableCors.SupportsCredentials = true;
        enableCors.PreflightMaxAge = 30 * 60;
        GlobalConfiguration.Configuration.EnableCors(enableCors);
    }
