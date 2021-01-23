    public class MyViewModel : ViewModelBase
    {
        private ObservableCollection<DataItem> items;
        public ObservableCollection<DataItem> Items
        {
            get { return items; }
            set
            {
                items = value;
                RaisePropertyChanged("Items");
            }
        }
    }
