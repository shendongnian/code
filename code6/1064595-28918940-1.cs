    public class TrayIconWrapper : ITrayIcon
    {
        private readonly TaskbarIcon icon;
        public TrayIconWrapper(TaskbarIcon icon)
        {
            this.icon = icon;
        }
        public bool IsDisposed { get; private set; }
        public void Dispose()
        {
            icon.Dispose();
            IsDisposed = true;
        }
        public void Show()
        {
            icon.Visibility = Visibility.Visible;
        }
        public void Hide()
        {
            icon.Visibility = Visibility.Collapsed;
        }
        public void ShowBalloonTip(string title, string message)
        {
            icon.ShowBalloonTip(title, message, BalloonIcon.Info);
        }
        public void ShowBalloonTip(object rootModel, PopupAnimation animation, TimeSpan? timeout = null)
        {
            var view = ViewLocator.LocateForModel(rootModel, null, null);
            ViewModelBinder.Bind(rootModel, view, null);
          
            icon.ShowCustomBalloon(view, animation, timeout.HasValue ? (int)timeout.Value.TotalMilliseconds : (int?)null);
        }
        public void CloseBalloon()
        {
            icon.CloseBalloon();
        }
    }
