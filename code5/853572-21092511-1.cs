    public class BindingController
    {
        public BindingController()
        {
            this.Downloads = new ObservableCollection<Download>();
        }
        public ObservableCollection<Download> Downloads { get; private set; }
    }
