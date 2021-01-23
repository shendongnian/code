    public class MyClass: PropertyChangedBase
    {
        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged("Count"); //This is important!!!!
            }
        }
    
        public void StartCounting()
        {
            while (Count != 3)
            {
                Count++; //No need to marshall this operation to the UI thread. Only the property change notification is required to run on the Dispatcher thread.
            }
        }
    }
