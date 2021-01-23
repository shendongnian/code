    public class AccountRole: IdentityUserRole<TKey>
    {
        public override TKey RoleId
        {
            get;
            set;
        }
        public override TKey UserId
        {
            get;
            set;
        }
        public IdentityUserRole()
        {
        }
        public string somenewproperty(){
            get; set;
        }
    }
