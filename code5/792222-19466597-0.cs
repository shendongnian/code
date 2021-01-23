    public static void AcquirePushChannel()
    {
        CurrentChannel = HttpNotificationChannel.Find("MyPushChannel");
    
    
        if (CurrentChannel == null)
        {
            CurrentChannel = new HttpNotificationChannel("MyPushChannel");
            CurrentChannel.Open();
            if (!CurrentChannel.IsShellToastBound)
            {
                CurrentChannel.BindToShellTile();
            }
            CurrentChannel.BindToShellToast();
    
        }
        if (!CurrentChannel.IsShellTileBound)
        {
            CurrentChannel.BindToShellToast();
        }
    
            CurrentChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(Push_NotificationChannelChanged);
            CurrentChannel.ShellToastNotificationReceived += CurrentChannel_ShellToastNotificationReceived;
    }
