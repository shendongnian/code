    var user = await db.AspNetUsers
            .Where(u => u.AspNetRoles.Any(r => r.Id == roleId) || roleId == 0)
            .Include(u => u.AspNetRoles)
            .SelectMany(u => new UserDTO
            {
                Email = u.Email,
                RoleSingleId = u.AspNetRoles.Id,
                UserId = u.Id,
                UserName = u.UserName
            })
            .SingleOrDefault();
