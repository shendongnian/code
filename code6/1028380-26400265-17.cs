    TestChrome.Run("Hello Google", I => {
        I.Open("http://master.neutrino.com");
        I.Enter("myUserName").In("#txtUsername");
        I.Enter("myPassword").In("#txtPassword");
        I.Click("#btnLogin");
        IExtension.StartTimer(I);
        I.Enter("Fred Bloggs\r\n").In("#inputGlobalSearch");
        IExtension.StopTimer(I);
        I.Wait(1);
    });
