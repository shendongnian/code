    bool created;
    var eve = new System.Threading.EventWaitHandle(
        false,
        EventResetMode.AutoReset,
        "MyAppHandle",
        out created);
    if(!created)
    {
        eve.Set();
        Environment.Exit(-1); // Always use an exit error code if you're expecting to call from the console!
    }
