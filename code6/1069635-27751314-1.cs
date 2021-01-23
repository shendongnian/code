    Task<string> task1 = GetUsername();
    string username = await task1; // blocks(or "waits") here until GetUsername returns
    
    Task<string> task2 = GetConfig(username); // since we have the return from above, we can pass it here
    string config = await task2 ; // blocks here until GetConfig returns
