    TestChrome.Run("Hello Google", I => {
        I.Open("http://master.neutrino.com");
        I.Enter("myUserName").In("#txtUsername");
        I.Enter("myPassword").In("#txtPassword");
        I.Click("#btnLogin");
        I.StartTimer();
        I.Enter("Fred Bloggs\r\n").In("#inputGlobalSearch");
        I.StopTimer();
        I.Wait(1);
    });
