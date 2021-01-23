    public class MyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SomeObject> Items
        {
            get { /* ... */ }
        }
        public SomeItem SelectedItem
        {
            get { /* ... */ }
            set { /* ... */ }
        }
    }
