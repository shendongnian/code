    var TestChrome = Require<F14N>()
        .Init<FluentAutomation.SeleniumWebDriver>()
        .Bootstrap("Chrome")
        .Config(settings => {
            // Easy access to FluentAutomation.Settings values
            settings.DefaultWaitUntilTimeout = TimeSpan.FromSeconds(1);
        });
    TestChrome.Run("Hello Google", I => {
        I.Open("http://master.neutrino.com");
        I.Enter("myUserName").In("#txtUsername");
        I.Enter("myPassword").In("#txtPassword");
        I.Click("#btnLogin");
        StopWatch sw = new StopWatch()
        sw.Start();
 
        I.Enter("Fred Bloggs\r\n").In("#inputGlobalSearch");
        sw.Stop();
        Debug.Write(sw.ElapsedMilliseconds);
 
        I.Wait(1);
    });
