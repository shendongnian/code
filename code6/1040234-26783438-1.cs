        public class ListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private string textToDisplay;
        public string TextToDisplay
        {
            get { return textToDisplay; }
            set { textToDisplay = value; OnPropertyChanged("TextToDisplay"); }
        }
        public ListViewModel(string value)
        {
            TextToDisplay = value;
        }
    }
    }
