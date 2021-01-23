    public class DashboardAdapter
    {
        readonly MyBrokerService service;
        public bool IsConnected { get; set; }
 
        public DashboardAdapter()
        {
            // Create your connection to the WCF broker service
            // Pseudo code for the connection, replace with your actual implementation
            service = new MyBrokerService();
            service.onConnectionStatusChanged += (sender, e) => {
                IsConnected = e.isConnected;
            };
        }
    }
