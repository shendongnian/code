    using (var ctx = new UserProfileEntities())
    {
         
         UserProfile user = ctx.UserProfiles.Find( userId );
         if( user != null )
         { 
             int debt = user.MaxDebt;
             ...
         }         
    }
