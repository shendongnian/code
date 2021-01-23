        using (var runner = AssemblyRunner.WithAppDomain(testAssembly))
        {
            runner.OnDiscoveryComplete = OnDiscoveryComplete;
            runner.OnExecutionComplete = OnExecutionComplete;
            runner.OnTestFailed = OnTestFailed;
            runner.OnTestSkipped = OnTestSkipped;
            
            Console.WriteLine("Discovering...");
            runner.Start(typeName);
            
            finished.WaitOne();  // A ManualResetEvent
            finished.Dispose();
            
            return result;
        }
