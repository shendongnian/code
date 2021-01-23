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
            .GroupBy(key => new { key.Email, key.UserId, key.UserName },
            (key, agg) => new UserDTO 
                {
                    Email = key.Email,
                    UserId = key.Id,
                    UserName = key.UserName,
                    RoleSingleId = agg.Max(a => a.RoleSingleId),
                })
            .ToListAsync();
