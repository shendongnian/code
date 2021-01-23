    public class TabContent
    {
        ...
        public RelayCommand CloseTabCommand { get; private set; }
        public TabContent()
        {
            CloseTabCommand = new RelayCommand(OnTabClosing);
        }
        public event EventHandler TabClosing;
        void OnTabClosing()
        {
            var handler = TabClosing;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
