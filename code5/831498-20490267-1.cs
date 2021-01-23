    private static async void SomeButtonClick()
    {
        var mgr = new SessionManager();
        var success = await mgr.StartUp("string");
        if (success)
        {
            Console.WriteLine(mgr.SessionId);
            // update ui or whatever
        }
    }
