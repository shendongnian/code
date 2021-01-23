    host.AddServiceEndpoint(typeof(IFoo), new BasicHttpBinding(), "");
    
    // this will force WindowsFormsSynchronizationContext to be created
    new Control();
    // create new sync context, and WCF will use it, not WinForms context
    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
    
    host.Open(); // WCF will respond
    Console.ReadKey(); // main thread is blocked
