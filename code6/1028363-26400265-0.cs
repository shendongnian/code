    TestChrome.Run("Hello Google", I => {
        I.Open("http://master.neutrino.com");
        I.Enter("myUserName").In("#txtUsername");
        I.Enter("myPassword").In("#txtPassword");
        I.Click("#btnLogin");
    // want to log timing here 
        StopWatch sw = new StopWatch()
        sw.Start();
 
        I.Enter("Fred Bloggs\r\n").In("#inputGlobalSearch");
        sw.Stop();
        Debug.Write(sw.ElapsedMilliseconds);
 
       I.Wait(1);
    //log timing here also
    ...etc
    });
