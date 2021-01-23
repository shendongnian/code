    var roleContracts = context.Roles
        .OrderBy(role => role.Name)
        .Select(
            role => new RoleContract() {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                NumberOfUsers = role.Users.Count()
            })
        .ToList(); 
