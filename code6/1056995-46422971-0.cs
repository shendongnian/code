    using System.Linq;
    using System.Data;
    using System.Data.Entity;
                var db = new ApplicationDbContext();
                var Users = db.Users.Include(u => u.Roles);
    
                foreach (var item in Users)
                {
                    string UserName = item.UserName;
                    string Roles = string.Join(",", item.Roles.Select(r=>r.RoleId).ToList());
                }
