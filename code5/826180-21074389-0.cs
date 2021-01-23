        public class IdentityUser : IUser {
            public IdentityUser(){...}
            public IdentityUser(string userName) (){...}
            public string Id { get; set; }
            public string UserName { get; set; }
            public string PasswordHash { get; set; }
            public string SecurityStamp { get; set; }  
        }
