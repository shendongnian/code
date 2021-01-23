    [HubName("sessiondata")]
    public class SessionDataHub : Hub
    {
        private ObservableCollection<string> sessions = new ObservableCollection<string>();
        public SessionDataHub()
        {
            sessions.CollectionChanged += sessions_CollectionChanged;
        }
        private void sessions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Clients.All.someOneJoined(e.NewItems.Cast<string>().First());
            }
        }
        public override Task OnConnected()
        {
            return Task.Factory.StartNew(() =>
            {
                var youAre = Context.ConnectionId;
                Clients.Caller.myNameIs(youAre);
                sessions.Add(youAre);
            });
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            // TODO: implement this as well. 
            return base.OnDisconnected(stopCalled);
        }
    }
