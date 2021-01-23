        private void RunThread()
        {
            try
            {
                var worker = new Thread(Worker);
                SetFormEnabledStatus(false);
                _usuccessful = false;
                worker.Start();
                // give up if no response before timeout
                worker.Join(60000);      // TODO - Add timeout to config
                worker.Abort();
            }
            finally
            {
                SetFormEnabledStatus(true);
            }
        }
        
        private void Worker()
        {
            try
            {
                _successful= false;
                ThisMethodMightReturnSomethingAndICantChangeIt();
                _successful = true;
            }
            catch (ThreadAbortException ex)
            {
                // nlog.....
            }
            catch (Exception ex)
            {
                // nlog...
            }
        }
