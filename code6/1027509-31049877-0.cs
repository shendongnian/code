    while (service.Status == ServiceControllerStatus.StopPending) //If it is stop pending, wait for it
                    {
                        System.Threading.Thread.Sleep(30 * 1000); //  thread sleep for 30 seconds
                        service.Refresh(); // refreshing status
                        if (service.Status == ServiceControllerStatus.Stopped)
                        {
                            Comments = "Service " + serviceName + " stopped successfully. ";
                          
                        }
                    }
