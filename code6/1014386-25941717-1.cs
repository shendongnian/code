    class AlertHandler
    {
        public void RegisterHandler(UserAccount toMonitor)
        {
            toMonitor.SecurityAlert += HandleSecurityAlert;
        }
        private void HandleSecurityAlert(String username, String password)
        {
            Console.WriteLine("Got event: " + username + " => " + password);
        }
    }
