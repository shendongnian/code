        public void RestartService(string serviceName)
        {
            if (StopService(serviceName) == true)
            {
                Thread.Sleep(60000);
                if (StartService(serviceName) == true)
                {
                    MessageBox.Show("Service started succesfully");
                }
           }
        }
        private bool StartService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private bool StopService(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                if (service.Status != ServiceControllerStatus.Stopped)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                    return true;
                }
                else if (service.Status == ServiceControllerStatus.Stopped)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
