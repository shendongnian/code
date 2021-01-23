    public void NewMessage(IChatMessage message)
        {
            trayIcon = trayIconManager.GetOrCreateFor<IMainTrayIcon>();
            var notification = new ChatNotificationViewModel(message);
            trayIcon.ShowBalloonTip(notification, PopupAnimation.Slide, TimeSpan.FromSeconds(5));
        }
