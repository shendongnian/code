    //This is the method you want to run when the event fires
    private static void WhatIWantToDo()
    {
        //do stuff
    }
    //here is a delegate with the same signature as your method
    private delegate void MyDelegate();
    private static void Main()
    {
        Type t = Type.GetTypeFromProgID("MyOCX"); 
        object test = Activator.CreateInstance(t); 
        t.InvokeMember("LaunchBrowserWindow", System.Reflection.BindingFlags.InvokeMethod, null, test, new object[] { "cnn", "www.cnn.com" });
        //Get the event info object from the type
        var eventInfo = t.GetEvent("CloseWindow");
        //Create an instance of your delegate
        var myDelegate = new MyDelegate(WhatIWantToDo);
        //Pass the object itself, plus the delegate to the AddEventHandler method. In theory, this method should now run when the event is fired
        eventInfo.AddEventHandler(test, myDelegate);
    }
