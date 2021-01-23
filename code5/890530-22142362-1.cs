    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GroupName { get; set; }
        public string Email { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        public string Remark { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public virtual ICollection<Request> Requests { get; set; } 
    }
