    public class SPOUser
    {
    
        private SPOUser()
        {
            
        }
    
    
        /// <summary>
        /// Returns an encoded claim for the specified login name.
        /// </summary>
        /// <param name="context">Client Context for Tenant Admin site</param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public static string EncodeClaim(ClientRuntimeContext context, string loginName)
        {
            var tenant = new Tenant(context);
            var clientResult = tenant.EncodeClaim(loginName);
            context.ExecuteQuery();
            return clientResult.Value;
        }
    
        /// <summary>
        /// Returns a string that represents the decoded claim (the login name) for the specified encoded claim.
        /// </summary>
        /// <param name="context">Client Context for Tenant Admin site</param>
        /// <param name="encodedLoginName">A string that represents the encoded claim.</param>
        /// <returns></returns>
        public static string DecodeClaim(ClientRuntimeContext context, string encodedLoginName)
        {
            var tenant = new Tenant(context);
            var clientResult = tenant.DecodeClaim(encodedLoginName);
            context.ExecuteQuery();
            return clientResult.Value;
        }
    
    
        
    }
