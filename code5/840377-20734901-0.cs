    public interface IWindowManager
    {
        bool? ShowDialog(object rootModel, object context = null, IDictionary<string, object> settings = null);
        void ShowPopup(object rootModel, object context = null, IDictionary<string, object> settings = null);
        void ShowWindow(object rootModel, object context = null, IDictionary<string, object> settings = null);
    }
