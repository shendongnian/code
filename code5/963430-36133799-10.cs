        try
        {
            var newUser = userManager.FindByEmail(superuserToInsert.Email);
            userManager.AddToRole(newUser.Id, "Super users");
        }
        catch 
        {
        }
