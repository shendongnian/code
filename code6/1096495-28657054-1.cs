    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        private IPrincipal _currentUser;
        public ApplicationDbContext(IPrincipal currentUser)
        {
            _currentUser = currentUser;
        }
    }
