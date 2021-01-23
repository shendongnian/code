    public class ApplicationUserStore : UserStore<TestUser>
    {
        public ApplicationUserStore(TestContext context) : base(context)
        {
        }
        public override TestUser FindByIdAsync(string userId)
        {
            return Users.Include(c => c.Customer).FirstOrDefault(u => u.Id == userId);
            //you may want to chain in some other .Include()s like Roles, Claims, Logins etc..
        }
    }
