     async Task<int> TestAsync()
    {
       ///Initial Code
       int m=3;
       ///Call the task
       var X =foo4Async(m);
       ///Between
       ///Do something while waiting comes here
       ///..
       var Result =wait X;
       ///Final
       ///Some Code here
       return Result;
    }
