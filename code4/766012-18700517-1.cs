    var clients = db.Clients.Include(c => c.Gender)
                            .Include(c => c.Setting)
                            .Include(c => c.UserProfile)
                            .OrderBy(c => c.ClientId)
                            .Where(u => u.UserProfileId == WebSecurity.CurrentUserId);
