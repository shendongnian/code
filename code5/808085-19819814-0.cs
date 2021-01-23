    T ExecuteInTryCatch<T>(Func<T> codeBlock)
    {
        try
        {
            codeBlock();
        }
        catch (SomeException e)
        {
            //Do Something
        }
     }
