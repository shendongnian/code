        public class ApplicationUserStore<TUser> : UserStore<TUser> 
      where TUser : ApplicationUser {
        public ApplicationUserStore(DbContext context)
          : base(context) {
        }
    
        public int TenantId { get; set; }
    }
