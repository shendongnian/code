    // you might need to wrap this in a Dispatcher.BeginInvoke (see below)
    // if you are not calling from the main UI thread
    CallSomeMethodToSetVisualCuesIfYouHaveOne();
    Task.Factory.StartNew(() =>
    {
        // code in this block will run in a background thread...
    }
    .ContinueWith(task =>
    {
       // if you called the task from the UI thread, you're probably
       // ok if you decide not to wrap the optional method call below
       // in a dispatcher begininvoke... 
       Application.Current.Dispatcher.BeginInvoke(new Action(()=>
       {
           CallSomeMethodToUnsetYourVisualCuesIfYouHaveAnyLOL();
       }));
    }
