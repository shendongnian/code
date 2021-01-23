    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string GravatarHash { get; set; }
        public string Country { get; set; }
        public int OrganizationId { get; set; }
        public bool IsLocked { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public bool DataLoaded { get; set; }
    }
