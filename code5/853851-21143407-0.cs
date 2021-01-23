    /// <summary>
        /// Get sAMAccountName for matching UserPrincipalName (UPN)
        /// </summary>
        /// <param name="domain">Domain name</param>
        /// <param name="userName">Username</param>
        /// <returns></returns>
        protected string GetSamUsername(string domain, string userName)
        {
            string samName;
            using (var pc = new PrincipalContext(ContextType.Domain, domain))
            {
                var user = UserPrincipal.FindByIdentity(pc, userName); // Search for this user
                if (user == null) return null; // If user is not there, why go forward
                samName = user.SamAccountName;
            }
            return samName;
        }
 
