    User k = new User()
             {
                 UserName = "Kishan",
                 Roles = new List<Role>()
                 {
                     new Role() { Name = "Supremo" }
                 }
             }
    context.Users.Add(u);
    context.SaveChanges();
    User r = new User()
             {
                 UserName = "Rama",
                 Roles = new List<Role>()
                 {
                     context.Roles.Single(r => r.Name == "Supremo")
                 }
             }
    context.SaveChanges();
