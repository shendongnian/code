    static void SetIfNotNull(ref string target, string source)
    {
       if (source != null)
          target = source;
    }
    
    SetUpdateUserValue(User updateUser, User user)
    {
        SetIfNotNull(ref updateUser.FirstName, user.FirstName != null);
        SetIfNotNull(ref updateUser.LastName,  user.LastName != null);
        ...
    }
