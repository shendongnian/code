    class UsersModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
    class Role
    {
        Id { get; set; }
        Name { get; set; }
    }
