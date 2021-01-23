    void WithUser(Action<User> action)
    {
      try
      {
         var user = User;
         if (user != null) action(user);
      }
      catch(Exception e)
      {
        // Log it...
      }
    }
