    if (theUser != null)
    {
        if (theUser.IsAccountLockedOut())
        {
            // account locked out
        }
        // Enabled is nullable bool
        if (!(theUser.Enabled == true))
        {
            // account disabled
        }
        if (theUser.LastLogon == null || 
            theUser.LastLogon < DateTime.Now - TimeSpan.FromDays(150))
        {
            // never logged on or last logged on long time ago
            // see below in the text for important notes !
        }
    }
