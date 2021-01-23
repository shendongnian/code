    public class SomeClass
    {
        ObservableCollection<int> myObservableColl = new ObservableCollection<int>();
        public SomeClass()
        {
            myObservableColl.CollectionChanged += MainWindowViewModel_CollectionChanged;
        }
        private void AddItem(int number)
        {
            myObservableColl.CollectionChanged -= MainWindowViewModel_CollectionChanged;
            myObservableColl.Add(number);
            myObservableColl.CollectionChanged += MainWindowViewModel_CollectionChanged;
        }
        private void MoveItem(int oldIndex, int newIndex)
        {
            myObservableColl.CollectionChanged -= MainWindowViewModel_CollectionChanged;
            myObservableColl.Move(oldIndex, newIndex);
            myObservableColl.CollectionChanged += MainWindowViewModel_CollectionChanged;
        }
        // etc, etc.
    }
