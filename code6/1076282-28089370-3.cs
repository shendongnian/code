    class UserRoles
    {
        public string Username { get; set; }
        public Guid Value { get; set; }
        public List<Guid> Roles { get; set; }
        public UserRoles()
        {
            Roles = new List<Guid>();
        }
    }
