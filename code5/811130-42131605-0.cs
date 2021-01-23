        public string GetUserEmail(string username)
        {
            using (var pctx = new PrincipalContext(ContextType.Domain))
            {
                using (UserPrincipal up = UserPrincipal.FindByIdentity(pctx, username))
                {
                    return up != null && !string.IsNullOrEmpty(up.EmailAddress) ? up.EmailAddress : string.Empty;
                }
            }
        }
