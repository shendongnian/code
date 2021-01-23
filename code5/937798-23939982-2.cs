    var catWithRev = ctx.Categories
                    .Include(c => c.AccessRight.Roles)
                    .Include(c => c.AccessRight.Permissions)
                    //.Include(c => c.Revisions)
                    .Select(c => new
                    {
                        Category = c,
                        LastRevision = c.Revisions
                            .OrderByDescending(r => r.DateCreated)
                            .FirstOrDefault()
                    })
                    .FirstOrDefault(i => i.Id == id);
