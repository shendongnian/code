    public interface ITrayIcon : IDisposable
    {
        void Show();
        void Hide();
        void ShowBalloonTip(string title, string message);
        void ShowBalloonTip(object rootModel, PopupAnimation animation, TimeSpan? timeout = null);
        void CloseBalloon();
    }
