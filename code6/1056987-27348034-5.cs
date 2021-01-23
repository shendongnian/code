    public class UserWithRole
    {
        public string UserName {get;set;} // You can alias the SQL output to give these better names
        public string Name {get;set;}
    }
    
    using (var context = new DbContext())
    {
        var sql = @"
                    SELECT AspNetUsers.UserName, AspNetRoles.Name 
                    FROM AspNetUsers 
                    LEFT JOIN AspNetUserRoles ON  AspNetUserRoles.UserId = AspNetUsers.Id 
                    LEFT JOIN AspNetRoles ON AspNetRoles.Id = AspNetUserRoles.RoleId
                    WHERE AspNetUsers.Id = @Id";
        var idParam = new SqlParameter("Id", theUserId);
    
        var result = context.Database.ExecuteQuery<UserWithRole>(sql, idParam);
    }
