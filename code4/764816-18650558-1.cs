        static void CheckForProcessExistence()
        {
            foreach (Process exe in Process.GetProcesses())
            {
                if (exe.ProcessName.Contains("WINWORD"))
                {
                    Console.WriteLine("Yeah!Process is running");
                    exe.WaitForExit();
                    Console.WriteLine("Process Exited");
                    Environment.Exit(0);
                }
            }
        }
