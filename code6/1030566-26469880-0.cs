    class Reader
    {
        // other stuff
        Timer _updateTimer;
        public void Connect(ipAddress, TimeSpan pollingFrequency)
        {
            // Do the connection
            // Then set up the timer
            _updateTimer = new Timer(UpdateProc, null, 
                pollingFrequency, pollingFrequency);
        }
        
        private void UpdateProc(object state)
        {
            // poll the device here, and do any update
        }
    }
