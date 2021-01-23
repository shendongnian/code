     public static ICollection<PSObject> RunScriptText(string scriptFullPath, ICollection<CommandParameter> parameters = null)
            {
                var runspace = RunspaceFactory.CreateRunspace();
                runspace.Open();
                var pipeline = runspace.CreatePipeline();
                
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    var initial = InitialSessionState.CreateDefault();
                    Console.WriteLine("Importing ServerManager module");
                    initial.ImportPSModule(new[] { "ServerManager" });
    
                    PowerShellInstance.Runspace = runspace;
    
                    PowerShellInstance.AddScript("Set-ExecutionPolicy Unrestricted");
                    PowerShellInstance.AddScript("Get-ExecutionPolicy");
                    PowerShellInstance.Invoke();
                    
                    var cmd = new Command(scriptFullPath);
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    pipeline.Commands.Add(cmd);
                    var results = pipeline.Invoke();
                    pipeline.Dispose();
                    runspace.Dispose();
                    return results;
                }
                return null;
            }
