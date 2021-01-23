    NotificationCompat.Builder builder = new NotificationCompat.Builder(this)
        .SetContentTitle("Button Clicked")
        .SetSmallIcon(Resource.Drawable.ic_stat_button_click)
        .SetContentText(String.Format("The button has been clicked {0} times.", _count));
    
        // Obtain a reference to the NotificationManager
        NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
        notificationManager.Notify(ButtonClickNotificationId, builder.Build());
