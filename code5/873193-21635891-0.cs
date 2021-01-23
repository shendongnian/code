    Runspace runspace = RunspaceFactory.CreateRunspace();
    string scriptText = 
           "$wug = New-Object -ComObject CoreAsp.EventHelper;" +
           "$wug.SendChangeEvent(2,519,1)";
    runspace.Open();
    for (int x = 0; x < 1000; x++)
        {
                Console.WriteLine("Running Event "+(x+1).ToString());
                Pipeline pipeline = runspace.CreatePipeline();
                pipeline.Commands.AddScript(scriptText);
                pipeline.Commands.Add("Out-String");
                pipeline.Invoke();
                Thread.Sleep(1000);
                
         }
    runspace.Close();
