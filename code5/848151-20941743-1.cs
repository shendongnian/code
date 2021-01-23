    using (var ctx = new UserProfileEntities())
    {
         var user = ctx.UserProfiles.Where( u => u.UserId == userId );
         int debt = user.MaxDebt;
    }
