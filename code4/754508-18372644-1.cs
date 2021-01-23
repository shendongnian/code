    public class ViewModel
    {
        ObservableCollection<string> m_Items
            = new ObservableCollection<string>(Enumerable.Range(1, 100).Select(x => x.ToString()));
        public ObservableCollection<string> Items { get { return m_Items; } }
        ObservableCollection<object> m_Selected = new ObservableCollection<object>();
        public ObservableCollection<object> Selected { get { return m_Selected; } }
    }
