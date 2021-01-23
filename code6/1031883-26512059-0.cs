    remainder =>
    {
       Calls c = new Calls();
       c.DialingNumber = "number..";
       c.DialResult = "result...;
       Dispatcher.Invoke(()=> // Get the dispatcher from your window and use it here
       {
           items.Add(c);
       }
    },
