    public NotificationCollection() : this(Enumerable.Empty<Notification>())
    {
    }
    public NotificationCollection(IEnumerable<Notification> items)
        : base(items)
    {
        this.CollectionChanged += NotificationCollection_CollectionChanged;
        this.PropertyChanged += NotificationCollection_PropertyChanged;
    }
