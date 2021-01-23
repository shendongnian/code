    public class ApplicationUser : IUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public ApplicationUser(string userName): this()
        {
            UserName = userName;
        }
        public virtual string Id { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string UserName { get; set; }
    }
