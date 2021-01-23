    public class UserProjectRights
    {
        [Key]
        public ApplicationUser User { get; set; }
        [Key]
        public Project Project { get; set; }
    
        public AccessRight Right { get; set; }
    }
