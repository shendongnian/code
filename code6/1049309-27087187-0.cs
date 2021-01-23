    var user1 = await db.AspNetRoles
            .Include(u => u.AspNetUsers)
            .Select(u => new RoleGetDTO
            {
                RoleId = u.Id,
                Name = u.Name,
                UsersCount = u.AspNetUsers.Count()
            })
            .ToListAsync();
