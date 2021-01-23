    public class RoleDependent
    {
        public String Id { get; set; }
        [ForeignKey("Id")]
        public virtual IdentityRole IdentityRole { get; set; }
    }
