    public class VpnClientMainWindowViewModel
    {
        public VpnClientMainWindowViewModel() {
            var perthServer = new ServerModel
            {
                Name = "Perth",
                Hostname = "localhost",
                Ip = "127.0.0.1",
                Latency = 0
            };
            var sydneyServer = new ServerModel
            {
                Name = "Sydney",
                Hostname = "localhost",
                Ip = "127.0.0.1",
                Latency = 0
            };
            this.TheServers.Add(perthServer);
            this.TheServers.Add(sydneyServer);
            this.CurrentlySelectedServer = new CurrentlySelectedServerViewModel
            {
                CurrentlySelectedServerModel = this.TheServers[0]
            };
        }
        private List<ServerModel> _theServers = new List<ServerModel>();
        private CurrentlySelectedServerViewModel _currentlySelectedServer;
        public List<ServerModel> TheServers
        {
            get { return _theServers; }
            set { _theServers = value; }
        }
        public CurrentlySelectedServerViewModel CurrentlySelectedServer
        {
            get { return _currentlySelectedServer; }
            set { _currentlySelectedServer = value; }
        }
    }
    public class CurrentlySelectedServerViewModel
    {
        private ServerModel _CurrentlySelectedServerModel;
        public ServerModel CurrentlySelectedServerModel
        {
            get { return _CurrentlySelectedServerModel; }
            set { _CurrentlySelectedServerModel = value; }
        }        
    }
    public class ServerModel
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string hostName;
        public string Hostname
        {
            get { return hostName; }
            set { hostName = value; }
        }
        private string ip;
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private int latency;
        public int Latency
        {
            get { return latency; }
            set { latency = value; }
        }
        
    }
     
