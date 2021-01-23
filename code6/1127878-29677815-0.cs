    using System.Runtime.CompilerServices;
    
    class SomeClass : INotifyPropertyChanged
    {
        private int somefield;
        public int SomeProperty
        {
            get { return somefield; }
            set 
            {
                somefield = value;
                OnPropertyChanged();
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
