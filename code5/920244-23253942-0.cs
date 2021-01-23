    Thread awesomiumThread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
    {
         WebCore.Started += (s, e) => {
             awesomiumContext = SynchronizationContext.Current;
         };
                    
         WebCore.Run();
    }));
    
    awesomiumThread.Start();
    
    WebCore.Initialize(new WebConfig() { });
