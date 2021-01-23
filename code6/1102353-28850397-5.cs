    public class Parent : INotifyPropertyChanged
    {
        private ObservableCollection<Child> children;
        private Child m_SelectedChild;
        public Parent()
        {
            children = new ObservableCollection<Child>
            {
                new Child {Name = "C1"},
                new Child {Name = "C2"}
            };
        }
        public string Name { get; set; }
        public ObservableCollection<Child> Children
        {
            get { return children; }
        }
        public Child SelectedChild
        {
            get { return m_SelectedChild; }
            set
            {
                if (m_SelectedChild == value)
                    return;
                m_SelectedChild = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Child
    {
        public string Name { get; set; }
    }
