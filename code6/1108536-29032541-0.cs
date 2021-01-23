    public List<NotificationDataModel> NotificationsCollection
    {
        get { return notificationsCollection; }
        set
        {
            notificationsCollection = value;
            OnPropertyChanged("NotificationsCollection");
        }
    }
