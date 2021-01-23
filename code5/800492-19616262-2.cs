        using (SocialContext ctx = new SocialContext())
        {
            User u = new User()
            {
                UserName = "John"
            };
            User uu = new User()
            {
                UserName = "Jack"
            };
            uu.FriendShips.Add(u);
            u.FriendShips.Add(uu);
            ctx.Users.Add(u);
            ctx.SaveChanges();
        }
