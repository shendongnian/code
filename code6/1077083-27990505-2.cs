    public interface IWindowManagerEx : IWindowManager, IDisposable
    {
        bool? ShowDialog<TViewModel>(object context = null, IDictionary<string, object> settings = null);
        void ShowWindow<TViewModel>(object context = null, IDictionary<string, object> settings = null);
        void ShowPopup<TViewModel>(object context = null, IDictionary<string, object> settings = null);
        void ShowTrayIcon<TViewModel>(object context = null);
    }
