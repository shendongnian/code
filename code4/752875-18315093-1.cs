    class GoodClass
    {
        private int value;
        public int Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.OnPropertyChanged("Value");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name);
            }
        }
    }
