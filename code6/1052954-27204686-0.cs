    var users = query.Select(async u =>  new
    {
        FirstName = u.FirstName,
        LastName = u.LastName,
        IsGeek = await _userManager.IsInRoleAsync(u.Id, "Geek")
    });
