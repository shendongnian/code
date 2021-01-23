    void ExecuteInTryCatch(Action code)
    {
       try
       {
           code();
       }
       catch (MyException e)
       {
          do something
       }
    }
    ExecuteInTryCatch( ()=>{
        // stuff here
    });
