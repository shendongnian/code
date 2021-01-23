         protected override void OnStart(string[] args)
            {         
                    bool launchDebugger = false;
                    if (args.Count() > 0)
                    {
                        launchDebugger = args[0].ToLower() == "debug";
                    }
                   
                   
                    if (launchDebugger)
                    {                   
                       Debugger.Launch();
                    }    
    } 
