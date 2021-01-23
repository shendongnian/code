     private static void Main(string[] args)
            {
                // Display the welcome message.
                Console.Title = "PowerShell Console Host Sample Application";
                ConsoleColor oldFg = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("    Windows PowerShell Console Host Application Sample");
                Console.WriteLine("    ==================================================");
                Console.WriteLine(string.Empty);
                Console.WriteLine("This is an example of a simple interactive console host uses ");
                Console.WriteLine("the Windows PowerShell engine to interpret commands.");
                Console.WriteLine("Type 'exit' to exit.");
                Console.WriteLine(string.Empty);
                Console.ForegroundColor = oldFg;
    
                // Create the listener and run it. This method never returns.
                PSListenerConsoleSample listener = new PSListenerConsoleSample();
                listener.Run();
            }
    
            /// <summary>
            /// Initializes a new instance of the PSListenerConsoleSample class.
            /// </summary>
            public PSListenerConsoleSample()
            {
                // Create the host and runspace instances for this interpreter. 
                // Note that this application does not support console files so 
                // only the default snap-ins will be available.
                this.myHost = new MyHost(this);
                this.myRunSpace = RunspaceFactory.CreateRunspace(this.myHost);
                this.myRunSpace.Open();
    
                // Create a PowerShell object to run the commands used to create 
                // $profile and load the profiles.
                lock (this.instanceLock)
                {
                    this.currentPowerShell = PowerShell.Create();
                }
    
                try
                {
                   
                    this.currentPowerShell.AddScript("Add-PSSnapin Microsoft.Sharepoint.Powershell");
                    this.currentPowerShell.AddScript(@"C:\Users\Administrator\Desktop\Untitled1.ps1");
                    
                    this.currentPowerShell.Runspace = this.myRunSpace;
    
                    PSCommand[] profileCommands = Microsoft.Samples.PowerShell.Host.HostUtilities.GetProfileCommands("SampleHost06");
                    foreach (PSCommand command in profileCommands)
                    {
                        this.currentPowerShell.Commands = command;
                        this.currentPowerShell.Invoke();
                    }
                }
                finally
                {
                    // Dispose the PowerShell object and set currentPowerShell 
                    // to null. It is locked because currentPowerShell may be 
                    // accessed by the ctrl-C handler.
                    lock (this.instanceLock)
                    {
                        this.currentPowerShell.Dispose();
                        this.currentPowerShell = null;
                    }
                }
            }
    
            /// <summary>
