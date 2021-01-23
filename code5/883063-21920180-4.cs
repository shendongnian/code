    public ObservableCollection<NetworkObject> NetworkObjects
    {
        get
        {
            hhh networkObjects = new ObservableCollection<NetworkObject>(Clients);
            networkObjects.Add(Servers);
            return networkObjects;
        }
    }
