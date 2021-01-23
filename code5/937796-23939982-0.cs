    var category = db.Categories
                   .Include(i => i.AccessRight.Roles)
                   .Include(i => i.AccessRight.Permissions)
                   .Include(i => i.Revisions)
                   .FirstOrDefault(i => i.Id == id);
