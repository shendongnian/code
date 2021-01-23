    public void AccessPermissions(User user)
    {
        int UserLevel = 0;
	UserLevel += (user.Age>=18) ? 1:0;		// Add 1 if user is over 18
	UserLevel += (user.IsIsRegistred) ? 1:0;	// If registered, add another 1
	UserLevel += (user.IsPowerFull) ? 1:0;		// Add another 1 if powerful
	
	AccessGrantLevel( UserLevel );
    }
