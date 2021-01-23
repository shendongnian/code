    public void DoStuff()
    {
        var someKey = ConfigurationManager.AppSettings["SomeKey"];
        if (string.IsNullOrEmpty(someKey))
        {
            // provide view with friendly error
            // log error
            return;
        }
        // do stuff
    }
