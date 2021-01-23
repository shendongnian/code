        int i = 500;    
        while ( i > 0) {
            i = 0;
            foreach (var user in db.Member.Where(u => u.is_deleted == false && u.hash == null).Select(u => new { id = u.id, pass = u.web_password, hash = u.password_hash }).Take(500).ToList())
            {
               i++;
                    if (user.pass == null)
                    {
                        string newPass = RandomString(8);
                        var result = userManager.AddPasswordAsync(user.id, newPass).Result;
                        Console.WriteLine(
                            "UserID: {0}, Password: {1}, Hashed: {2}",
                            user.id,
                            newPass,
                           result.Succeeded);
                    }
                    else
                    {
                        var result = userManager.AddPasswordAsync(user.id, user.pass).Result;
                        Console.WriteLine(
                            "UserID: {0}, Password: {1}, Hashed: {2}",
                            user.id,
                            user.pass,
                           result.Succeeded);
                    }
                }
        }
