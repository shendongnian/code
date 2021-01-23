    void ExecuteInTryCatch(Action codeBlock)
    {
       try
       {
           codeBlock();
       }
       catch (MyException e)
       {
           //Do Something
       }
    }
