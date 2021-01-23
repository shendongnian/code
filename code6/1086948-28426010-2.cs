    public ProductsDataService : EntityFrameworkDataService<ProductsContext>
    {
        private static validator = new UserValidator();
        public ProductsDataService()
        {
            this.UseBasicAuthentification("My Realm", validator);
        }
        private class UserValidator : IUserValidator
        {
            public IPrincipal Validate(string username, string password)
            {
                // just an example implementation
                if (!"1234".Equals(password)) retur null;
                return new GenericPrincipal(
                    new GenericIdentity(username), "Admin", "User");
            }
        }
    }
