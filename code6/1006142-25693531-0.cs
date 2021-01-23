    public async Task<Result> MyAsyncMethod() 
    {
        try
        {
             // No need to use Task<Result> as await will unwrap the outter task
             return await _mySender.PostAsync();
         }
         catch (MyCustomException e)
         {
               // handle here
         }
    }
