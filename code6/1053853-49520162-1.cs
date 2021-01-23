    /// <summary>
    /// Dictionary of currently configured OAuth audience+policy to the B2C endpoint signing key cache.
    /// </summary>
    protected ConcurrentDictionary<string, OpenIdConnectCachingSecurityTokenProvider> AudiencePolicyMap = new ConcurrentDictionary<string, OpenIdConnectCachingSecurityTokenProvider>();
    /// <summary>
    /// Load the B2C authentication tenant list, creating a B2C endpoint security token provider
    /// which will bethe source of the token signing keys.
    /// </summary>
    /// <param name="aadInstance">The Active Directory instance endpoint URI</param>
    /// <param name="b2cAuthTenantList">The B2C authentication tenant list</param>
    public void LoadConfiguration(string aadInstance, List<B2CAuthTenant> b2cAuthTenantList) {
        // maintain a list of keys that are loaded
        HashSet<string> b2cAuthTenantSet = new HashSet<string>();
        // attempt to create a security token provider for each authentication tenant
        foreach(B2CAuthTenant b2cAuthTenant in b2cAuthTenantList) {
            // form the dictionary key
            string tenantKey = $"{b2cAuthTenant.Audience}:{b2cAuthTenant.PolicyId}";
            if (!AudiencePolicyMap.ContainsKey(tenantKey)) {
                try {
                    // attempt to create a B2C endpoint security token provider. We may fail if there is no policy 
                    // defined for that tenant
                    OpenIdConnectCachingSecurityTokenProvider tokenProvider = new OpenIdConnectCachingSecurityTokenProvider(String.Format(aadInstance, b2cAuthTenant.TenantName, b2cAuthTenant.PolicyId));
                    // add to audience:policy map
                    AudiencePolicyMap[tenantKey] = tokenProvider;
                    // this guy is new
                    b2cAuthTenantSet.Add(tenantKey);
                } catch (Exception ex) {
                    // exception has already been reported appropriately
                }
            } else {
                // this guys is already present
                b2cAuthTenantSet.Add(tenantKey);
            }
        }
        // at this point we have a set of B2C authentication tenants that still exist. Remove any that are not
        foreach (KeyValuePair<string, OpenIdConnectCachingSecurityTokenProvider> kvpAudiencePolicy in AudiencePolicyMap.Where(t => !b2cAuthTenantSet.Contains(t.Key))) {
            AudiencePolicyMap.TryRemove(kvpAudiencePolicy.Key, out _);
        }
    }
    /// <summary>
    /// Validate a security token. We are responsible for priming the token validation parameters
    /// with the specific parameters for the audience:policy, if found.
    /// </summary>
    /// <param name="securityToken">A 'JSON Web Token' (JWT) that has been encoded as a JSON object. May be signed using 'JSON Web Signature' (JWS)</param>
    /// <param name="tvps">Contains validation parameters for the security token</param>
    /// <param name="validatedToken">The security token that was validated</param>
    /// <returns>A claims principal from the jwt. Does not include the header claims</returns>
    public override ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters tvps, out SecurityToken validatedToken) {
        if (string.IsNullOrWhiteSpace(securityToken)) {
            throw new ArgumentNullException("Security token is null");
        }
        // decode the token as we need the 'aud' and 'tfp' claims
        JwtSecurityToken token = ReadToken(securityToken) as JwtSecurityToken;
        if (token == null) {
            throw new ArgumentOutOfRangeException("Security token is invalid");
        }
        // get the audience and policy
        Claim audience = token.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Aud);
        Claim policy = token.Claims.FirstOrDefault(c => c.Type == ClaimTypesB2C.Tfp);
        if ((audience == null) || (policy == null)) {
            throw new SecurityTokenInvalidAudienceException("Security token has no audience/policy id");
        }
        // generate the key
        string tenantKey = $"{audience.Value}:{policy.Value}";
        // check if this audience:policy is known
        if (!AudiencePolicyMap.ContainsKey(tenantKey)) {
            throw new SecurityTokenInvalidAudienceException("Security token has unknown audience/policy id");
        }
        // get the security token provider
        OpenIdConnectCachingSecurityTokenProvider tokenProvider = AudiencePolicyMap[tenantKey];
        // clone the token validation parameters so we can update
        tvps = tvps.Clone();
        // we now need to prime the validation parameters for this audience
        tvps.ValidIssuer = tokenProvider.Issuer;
        tvps.ValidAudience = audience.Value;
        tvps.AuthenticationType = policy.Value;
        tvps.IssuerSigningTokens = tokenProvider.SecurityTokens;
        // and call real validator with updated parameters
        return base.ValidateToken(securityToken, tvps, out validatedToken);
    }
