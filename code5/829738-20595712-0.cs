        private ObservableCollection<MyClass> _li;
        
        public ObservableCollection<MyClass> Li
        {
            get; 
            set
            {
                _li = value;
                NotifyPropertyChangedEvent("Li");      
            }
        }
