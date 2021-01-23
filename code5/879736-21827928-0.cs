     Parallel.ForEach<String>(Programs, Program =>
                {
                    Process myProcess = null;
    
                    // Start the process.
                    myProcess = Process.Start(@Program);
    
                    // Display the process statistics until 
                    // the user closes the program. 
                    do
                    {
                        if (!myProcess.HasExited)
                        {
                            // Refresh the current process property values.
                            myProcess.Refresh();
    
                            // Display current process statistics.
    
                            Console.WriteLine();
                            Console.WriteLine("Path: {0}, RAM: {1}", Program, (myProcess.WorkingSet64 / 1024 / 1024));
    
                            // Update the values for the overall peak memory statistics.
                            peakWorkingSet = myProcess.PeakWorkingSet64;
    
                            if (myProcess.Responding)
                            {
                                Console.WriteLine("Status: Running");
                            }
                            else
                            {
                                Console.WriteLine("Status: Not Responding!");
                            }
    
                            // Wait 2 seconds
                            Thread.Sleep(2000);
                        }
                    }
                    while (!myProcess.WaitForExit(1000));
    
                    Console.WriteLine();
                    Console.WriteLine("Process exit code: {0}", myProcess.ExitCode);
                    Console.WriteLine("Peak physical memory usage of the process: {0}", (peakWorkingSet / 1024 / 1024));
    
                    Console.WriteLine("Press any key to exit.");
                    System.Console.ReadKey();
                });
