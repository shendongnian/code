    public class MyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SomeObject> Items
        {
            get { /* ... */ }
        }
        public SomeObject SelectedItem
        {
            get { /* ... */ }
            set { /* ... */ }
        }
    }
