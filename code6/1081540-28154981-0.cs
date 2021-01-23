    public void HandleMessage(NotificationMessage message) {
        if (message.Notification.Equals(YourService.REFRESHCONTENTMESSAGE))
        {
            // Do stuff like navigating to a page.
        }
        else if (message.Notification.Equals(YourService.DELETECONTENTMESSAGE))
        {
            // Do something else.
        }
    }
