        public class User
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            //Navigation Property
            public List<Role> Roles { get; set; }
        }
        public class Role
        {
            public int Id { get; set; }
            public string Name { get; set; }
            //Navigation Property
            public List<User> Users { get; set; }
        }
