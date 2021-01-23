    try
    {
      using (new Impersonator("Admin Username", ".", "Admin Password"))
      {
        // Above method Content
        .
        .
        .
      }
    }
    catch (Exception ex)
    {
        return "Invalid Username or Password";
    }
