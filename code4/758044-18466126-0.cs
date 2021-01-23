    public class ServerInfo_ViewModel : INotifyPropertyChanged
    {
        public ServerInfo_ViewModel()
        {
            this.Servers = new ObservableCollection<ServerInfo>();
            LoadInitialServerList();
        }
        public ObservableCollection<ServerInfo> Servers
        {
            get 
            {
                return servers;
            }
            set
            {
                if(servers != value)
                {
                    servers = value; 
                    OnPropertyChanged("Servers");
                }
            }
        }
        private ObservableCollection<ServerInfo> servers;
        private void LoadInitialServerList()
        {
            servers.Add(new ServerInfo("Test", "Test", "Test", "Test", "Test"));
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
