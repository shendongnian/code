       public class ExchangeEventArgs : EventArgs
    {
        public EventType Type { get; private set; }
        public ItemId ItemId { get; private set; }
        public FolderId FolderId { get; private set; }
        public ExchangeEventArgs(EventType type, ItemId itemId, FolderId folderId)
        {
            Type = type;
            ItemId = itemId;
            FolderId = folderId;
        }
    }
    public class ExchangeClient : IDisposable
    {
        private ExchangeService _exchange;
        private SubscriptionBase _subscription;
        private StreamingSubscriptionConnection _connection;
        private bool _disposed;
        private bool _disposing;
        public event EventHandler<ExchangeEventArgs> ExchangeEvent;
        public event EventHandler<DisconnectEventArgs> Disconnected;
        public ExchangeClient(string userName, string password, string domain, ExchangeVersion version)
        {
            _exchange = new ExchangeService(version);
            _exchange.Credentials = new WebCredentials(userName, password);
            _exchange.AutodiscoverUrl(userName + "@" + domain);
            _connection = new StreamingSubscriptionConnection(_exchange, 30);
            CreateSubscription();
            _connection.OnNotificationEvent += OnNotificationEvent;
            _connection.OnSubscriptionError += OnSubscriptionError;
            _connection.OnDisconnect += OnDisconnect;
            _connection.Open();
        }
        private void CreateSubscription()
        {
            var ids = new FolderId[2] { new FolderId(WellKnownFolderName.Root), new FolderId(WellKnownFolderName.Inbox) };
            var events = new List<EventType>();
            events.Add(EventType.NewMail);
            if (_subscription != null)
            {
                ((StreamingSubscription)_subscription).Unsubscribe();
                _connection.RemoveSubscription((StreamingSubscription)_subscription);
            }
            _subscription = _exchange.SubscribeToStreamingNotifications(ids, events.ToArray());
            _connection.AddSubscription((StreamingSubscription)_subscription);
        }
        private void OnDisconnect(object sender, SubscriptionErrorEventArgs args)
        {
            if (args.Exception == null)
            {
                if (!_disposing && _connection != null)
                {
                    _connection.Open();
                }
            }
            else
            {
                if (Disconnected != null)
                    Disconnected(this, new DisconnectEventArgs("Exchange exception", args.Exception));
            }
        }
        public bool Reconnect()
        {
            try
            {
                if (!_disposing && _connection != null)
                {
                    CreateSubscription();
                    _connection.Open();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void OnSubscriptionError(object sender, SubscriptionErrorEventArgs args)
        {
           OnDisconnect(sender, args);
        }
        private void OnNotificationEvent(object sender, NotificationEventArgs args)
        {
            if (_subscription != null)
            {
                if (args.Subscription.Id == _subscription.Id)
                {
                    foreach (var notificationEvent in args.Events)
                    {
                        switch (notificationEvent.EventType)
                        {
                            case EventType.Status:
                                break;
                            case EventType.NewMail:
                                NotificationReceived(new ExchangeEventArgs(
                                notificationEvent.EventType,
                                ((ItemEvent)notificationEvent).ItemId, ((ItemEvent)notificationEvent).ParentFolderId));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }      
        public void Disconnect()
        {
            if (_connection.IsOpen)
                _connection.Close();
        }
        private void NotificationReceived(ExchangeEventArgs e)
        {
            if (ExchangeEvent != null)
            {
                ExchangeEvent(this, e);
            }
        }
        public void Dispose()
        {
            _disposing = true;
            Dispose(_disposing);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                if (_connection != null)
                {
                    if (_connection.IsOpen)
                        _connection.Close();
                    _connection = null;
                }
                _exchange = null;
                _disposed = true;
            }
        }
    }
