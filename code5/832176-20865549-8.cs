    private void StartService(String ServiceName)
    {
        TimeSpan timeout = TimeSpan.FromMilliseconds(30000); //30 seconds
        using (ServiceController service = new ServiceController(ServiceName))
        {
            try
            {
                service.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error starting service");
                return;
            }
            service.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }
    }
