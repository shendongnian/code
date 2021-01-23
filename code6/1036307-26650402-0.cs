    public UserProfile LoadUserDetails(Int64 userId)
    {
        // Assuming context.UserProfile is / can be converted to DbSet<UserProfile>
        // and the userId is the Key to the Entity
        using (var context = new Context())
        {
            return context.UserProfile.Find(userId);
        }
    }
