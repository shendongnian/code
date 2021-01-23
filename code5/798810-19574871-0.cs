    public static  AutoResetEvent messsageEvent= new AutoResetEvent(false);
    Public bool summaryDisplay()
    {
    var value=SomemethodCall()
    messsageEvent.Reset()//This blocks the Thread
    if(value.Exists)
    {
    messageEvent.Set();//This releases the Thread
    }
    }
