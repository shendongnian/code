    InitialSessionState iss = InitialSessionState.CreateDefault();
    iss.AuthorizationManager = new AuthorizationManager("MyShellId");
    iss.ImportPSModule(new string[] { "MSOnline" });
    #set commands we want to run concurrently
    string[] commands = new string[4] {
        "Start-Sleep -Seconds 5; 'Hi from #1'",
        "Start-Sleep -Seconds 7; 'Hi from #2'",
        "Start-Sleep -Seconds 3; 'Hi from #3'",
        "throw 'Danger Will Robinson'"
    };
    Dictionary<PowerShell, IAsyncResult> dict = new Dictionary<PowerShell, IAsyncResult>();
    //this loads the InitialStateSession for all instances
    //Note you can set the minimum and maximum number of runspaces as well
    using(RunspacePool rsp = RunspaceFactory.CreateRunspacePool(iss))
    {
        rsp.SetMinRunspaces(5);
        rsp.SetMaxRunspaces(10);
        rsp.Open();
        foreach(string cmd in commands)
        {
            PowerShell ps = PowerShell.Create();
            ps.AddScript(cmd);
            ps.RunspacePool = rsp;
            //Add parameters if needed with ps.AddParameter or ps.AddArgument
            dict.Add(ps,ps.BeginInvoke());            
        }
        do{
            List<PowerShell> toBeRemoved = new List<PowerShell>();
            foreach(KeyValuePair<PowerShell, IAsyncResult> kvp in dict)
            {
                if(kvp.Value.IsCompleted)
                {
                    try
                    {
                        PSDataCollection<PSObject> objs = kvp.Key.EndInvoke(kvp.Value);
                        foreach(PSObject obj in objs)
                        {
                            Console.WriteLine(obj);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    finally
                    {
                        toBeRemoved.Add(kvp.Key);
                    }
                }
            }
            foreach(PowerShell item in toBeRemoved)
            {
                dict.Remove(item);
            }
            //Wait before we check again
            Thread.Sleep(200);
        } while (dict.Count > 0)
        rsp.Close();
    }
    //Added to keep console open
    Console.Read();
