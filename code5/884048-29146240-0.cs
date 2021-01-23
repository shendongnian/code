        [Bind(Include = "UserList")]
        public class AdminViewModel
        {
            public AdminViewModel()
            {
                this.UserList = new List<User>();
            }
            public List<User> UserList { get; set; }
        }
