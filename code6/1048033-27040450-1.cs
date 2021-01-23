    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }
        public override System.Threading.Tasks.Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return Users.Include(u=>u.Customer).Include(u => u.Roles).Include(u => u.Claims).Include(u => u.Logins).FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
