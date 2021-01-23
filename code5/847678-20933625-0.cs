    public class NetworkData 
    {
        public NetworkData()
        {
            NetworkedComputersResults = new ObservableCollection<DiscoveredComputer>();
        }
        public ObservableCollection<DiscoveredComputer> NetworkedComputersResults{get;set;}
    }
