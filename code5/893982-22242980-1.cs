    localhost.MyDemo MyService;
    // try to get the proxy from Session state
    MyService = Session["MyService"] as localhost.MyDemo;
    if (MyService == null)
    {
        // create the proxy
        MyService = new localhost.MyDemo();
 
        // create a container for the SessionID cookie
        MyService.CookieContainer = new CookieContainer();
 
        // store it in Session for next usage
        Session["MyService"] = MyService;
    }
    // call the Web Service function
    Label1.Text += MyService.HelloWorld() + "<br />";
