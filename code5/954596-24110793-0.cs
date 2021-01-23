    foreach (Process process in Process.GetProcesses().Where(x => x.ProcessName == "devenv")) {
                using (PerformanceCounter pcProcess = new PerformanceCounter("Process", "% Processor Time", process.ProcessName))
                {
                    pcProcess.NextValue();
                    Thread.Sleep(1000);
                    return pcProcess.NextValue();
                }
            }
