    public class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        [Bindable(true)]
        public string Name
        {
            get { return name; }
            set
            {
                name = value; 
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        public Book(string name)
        {
            Name = name;
        }
    }
