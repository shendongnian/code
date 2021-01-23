    public async Task<bool> LoginUserAsync()
    {
        bool isSuccess;
        try
        {
            await ParseUser.LogInAsync(username, pass);
            isSuccess = true;
         }
         catch (Exception e)
         {
             // Log
             isSuccess = false;
         }
         return isSuccess;
    }
