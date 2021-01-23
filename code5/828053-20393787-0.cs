        static void Main(string[] args)
        {
            Package p = new Package();
            p.InteractiveMode = true;
            p.OfflineMode = true;
            // Add a Script Task to the package.
            TaskHost taskH = (TaskHost)p.Executables.Add(typeof(Microsoft.SqlServer.Dts.Tasks.ScriptTask.ScriptTask).AssemblyQualifiedName);
            // Run the package.
            p.Execute();
            // Review the results of the run.
            if (taskH.ExecutionResult == DTSExecResult.Failure || taskH.ExecutionStatus == DTSExecStatus.Abend)
                Console.WriteLine("Task failed or abended");
            else
                Console.WriteLine("Task ran successfully");
        }
