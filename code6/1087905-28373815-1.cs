    public class ViewModel
    {
        public ObservableCollection<string> CmbContent { get; private set; }
        public ViewModel()
        {
            CmbContent = new ObservableCollection<string>
            {
                "test 1", 
                "test 2"
            };
        }
    }
