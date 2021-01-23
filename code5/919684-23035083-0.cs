      foreach (ServiceController Svc in ServiceController.GetServices())
        {
            using (Svc)
            {
                //The short name of "Microsoft Exchange Service Host"
                if (Svc.ServiceName.Equals("YourServiceName"))
                {
                    if (Svc.Status != ServiceControllerStatus.Stopped)
                    {
                        if (Svc.CanStop)
                        {
                            try
                            {
                                Svc.Stop();
                                Svc.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 15));
                            }
                            catch
                            {
                                //Try to stop using Process
                                foreach (Process Prc in Process.GetProcessesByName(Svc.ServiceName))
                                {
                                    using (Prc)
                                    {
                                        try
                                        {
                                            //Try to kill the service process
                                            Prc.Kill();
                                        }
                                        catch
                                        {
                                            //Try to terminate the service using taskkill command
                                            Process.Start(new ProcessStartInfo
                                            {
                                                FileName = "cmd.exe",
                                                CreateNoWindow = true,
                                                UseShellExecute = false,
                                                Arguments = string.Format("/c taskkill /pid {0} /f", Prc.Id)
                                            });
                                            //Additional:
                                            Process.Start(new ProcessStartInfo
                                            {
                                                FileName = "net.exe",
                                                CreateNoWindow = true,
                                                UseShellExecute = false,
                                                Arguments = string.Format("stop {0}", Prc.ProcessName)
                                            });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
