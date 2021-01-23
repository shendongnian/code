    public void RemoteConnection() 
    {
      connectionInfo = new WSManConnectionInfo(false, remoteMachineName, 5985, "/wsman", shellUri, credentials);
            runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline(path);
            Command myCommand = new Command(path);
            CommandParameter testParam0 = new CommandParameter("-suma");
            myCommand.Parameters.Add(testParam0);
            CommandParameter testParam = new CommandParameter("x", "34");
            myCommand.Parameters.Add(testParam);
            CommandParameter testParam2 = new CommandParameter("y", "11");
            myCommand.Parameters.Add(testParam2);
            pipeline.Commands.Add(myCommand);
            var results = pipeline.Invoke();
            foreach (PSObject obj in results)
              Console.WriteLine(obj.ToString());
    }
