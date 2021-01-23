    // get your hub context
    var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub, INotificationHubContext>();
       
    // register it in your structure map
    ObjectFactory.Inject<IHubContext<INotificationHubContext>>(hubContext);
