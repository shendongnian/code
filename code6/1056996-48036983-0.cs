            public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var sql = @"
                SELECT AspNetUsers.UserName, AspNetRoles.Name As Role
                FROM AspNetUsers 
                LEFT JOIN AspNetUserRoles ON  AspNetUserRoles.UserId = AspNetUsers.Id 
                LEFT JOIN AspNetRoles ON AspNetRoles.Id = AspNetUserRoles.RoleId";
                //WHERE AspNetUsers.Id = @Id";
                //var idParam = new SqlParameter("Id", theUserId);
                var result = context.Database.SqlQuery<UserWithRoles>(sql).ToList();
                return View(result);
            }
        }
