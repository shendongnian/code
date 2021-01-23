                using (PowerShellProcessInstance instance = new PowerShellProcessInstance(new Version(4, 0), null, null, false))
            {
                using (var runspace = RunspaceFactory.CreateOutOfProcessRunspace(new TypeTable(new string[0]), instance))
                {
                    runspace.Open();
                    using (PowerShell powerShellInstance = PowerShell.Create())
                    {
                        powerShellInstance.Runspace = runspace;
                        var filePath = GetScriptFullName(powerShellScriptType);
                        powerShellInstance.Commands.AddScript(File.ReadAllText(filePath));
                        var includeScript = GetIncludeScript();
                        powerShellInstance.AddParameters(new List<string>
                    {
                        userName,
                        plainPassword,
                        includeScript
                    });
                        Collection<PSObject> psOutput = powerShellInstance.Invoke();
                        // check the other output streams (for example, the error stream)
                        if (powerShellInstance.Streams.Error.Count > 0)
                        {
                            // error records were written to the error stream.
                            // do something with the items found.
                            var exceptions = "";
                            foreach (var error in powerShellInstance.Streams.Error)
                            {
                                exceptions += error.Exception + "\n";
                            }
                            throw new InvalidPowerShellStateException(exceptions);
                        }
                        return psOutput;
                    }
                }
            }
