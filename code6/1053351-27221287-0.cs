    public class Person : IdentityUser, ITrackable
    {
    
        [Required]
        public string Name { get; set; }
    
        public Date DateOfBirth { get; set; }
    
        public string Address { get; set; }
    
        public DateTime DateCreated { get; set; }
    
        public DateTime DateModified { get; set; }
    }
