        public void NewMessage(IChatMessage message)
        {
            trayIcon = trayIconManager.GetOrCreateFor<TrayIconViewModel>();
            var notification = new ChatNotificationViewModel(message);
            trayIcon.ShowBalloonTip(notification, PopupAnimation.Slide, TimeSpan.FromSeconds(5));
        }
