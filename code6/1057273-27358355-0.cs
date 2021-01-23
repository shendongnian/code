    public class SomeClass
    {
        ObservableCollection<int> oc = new ObservableCollection<int>();
        public SomeClass()
        {
            oc.CollectionChanged += MainWindowViewModel_CollectionChanged;
        }
        private void AddItem(int number)
        {
            oc.CollectionChanged -= MainWindowViewModel_CollectionChanged;
            oc.Add(number);
            oc.CollectionChanged += MainWindowViewModel_CollectionChanged;
        }
        private void MoveItem(int oldIndex, int newIndex)
        {
            c.CollectionChanged -= MainWindowViewModel_CollectionChanged;
            c.Move(oldIndex, newIndex);
            c.CollectionChanged += MainWindowViewModel_CollectionChanged;
        }
        // etc, etc.
    }
