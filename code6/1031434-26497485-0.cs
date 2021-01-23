    IEnumerable<string> names = search.Name.Trim().Split(' ').OrderBy(s => s).Select(s => s.ToLower());
    
    IQueryable<User> users = db.Users;
    foreach (string name in names)
    {
        users = users.Where(u => u.NickName.ToLower().Contains(name) || u.FirstName.ToLower().Contains(name) || u.LastName.ToLower().Contains(name));
    }
    return users.ToList();
