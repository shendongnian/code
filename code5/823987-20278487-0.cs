    int id = User.GetId(user, password); // returns 0 if the user does not exists
  
    if (id != 0)
    {
     var newThread = new Thread(() => 
     {
          lock (User.CurrentUser) // Try to lock the static CurrentUser object
          { 
              User.LoadCurrentUser(id);  // Loads the CurrentUser object
          }
      }).Start();
      InitializeSystem(); 
      if (newThread.Join(someTimeOut))
         // use the User.CurrentUser object to apply the user's permissions.
      else
         // thread timed out, waiting for user load takes too long...
    
     }
