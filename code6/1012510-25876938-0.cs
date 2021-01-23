    public event EventHandler<NotificationEventArgs<string>> DisplayDetailsNotice;
    private DelegateCommand displayDetailsCommand;
    public DelegateCommand DisplayDetailsCommand
    {
        get { return displayDetailsCommand ?? (displayDetailsCommand = new DelegateCommand(DisplayDetails)); }
        }
    public void DisplayDetailsWindow()
    {
        //
        Notify(DisplayDetailsNotice, new NotificationEventArgs<string("DisplayDetails"));
    }
