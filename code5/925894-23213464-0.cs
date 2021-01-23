    {
        public virtual string Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public UserViewModel()
        {
            CustomerViewModel = new CustomerViewModel();
        }
        public CustomerViewModel CustomerViewModel { get; set; }
    }
