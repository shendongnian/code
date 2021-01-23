    public async Task<bool> LoginUserAsync(string username, string pass)
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
