        public class CustomRolesPolicy : IAuthorizationPolicy
        {
                Guid id = Guid.NewGuid();
        
                public bool Evaluate(EvaluationContext evaluationContext, ref object state)
                {
                    // will hold the combined roles
                    List<string> roles = new List<string>();
        
                    // get the authenticated client identity
                    IIdentity client = GetClientIdentity(evaluationContext);
        
                    var config = new NameValueCollection();
        
        
                    config.Add("applicationName", "/application_name");
                    config.Add("connectionStringName", "APPSEC_ASPNET");                
        
                    var roleProvider = new CustomRoleProvider();
                    roleProvider.Initialize("CustomRoleProvider", config);
        
                    roles.AddRange(roleProvider.GetRolesForUser(client.Name));
        
                    
                    evaluationContext.Properties["Principal"] =
                        new UserPrincipal(client, roles.ToArray());
        
        
                    return true;
                }
        
                public System.IdentityModel.Claims.ClaimSet Issuer
                {
                    get { return ClaimSet.System; }
                }
        
                public string Id
                {
                    get { return id.ToString(); }
                }
        
                private IIdentity GetClientIdentity(EvaluationContext evaluationContext)
                {
                    object obj;
                    if (!evaluationContext.Properties.TryGetValue("Identities", out obj))
                        throw new Exception("No Identity found");
        
                    IList<IIdentity> identities = obj as IList<IIdentity>;
                    if (identities == null || identities.Count <= 0)
                        throw new Exception("No Identity found");
        
                    return identities[0];
                }
    }
