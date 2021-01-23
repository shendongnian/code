    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name)
        {
        }
        public virtual Project Project { get; set; }
    }
