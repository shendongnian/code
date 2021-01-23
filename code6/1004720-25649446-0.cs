    public class Test : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            var e = PropertyChanged;
            if (e != null)
                e(this, args);
        }
        private bool isTrue;
        public Boolean IsTrue
        {
            get { return isTrue; }
            set
            {
                if (isTrue == value)
                    return;
                isTrue = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsTrue"));
            }
        }
        public string Name { get; private set; }
        public Test(Boolean isTrue, string name)
        {
            this.isTrue = isTrue;
            Name = name;
        }
    }
