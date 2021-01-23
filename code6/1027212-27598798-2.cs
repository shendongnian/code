        public static bool IsAuthenticated(string username_, string password_)
        {
            using (var pc = new PrincipalContext(ContextType.Domain, DomainManager.DomainName))
                return pc.ValidateCredentials(username_, password_);
        }
