        public bool ValidateCredentials(string domain, string username, string password)
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain))
            {
                return context.ValidateCredentials(username, password);
            }
        }
