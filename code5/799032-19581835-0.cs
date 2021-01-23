    public class PigLatinConverter : INotifyPropertyChanged
    {
        private string _originalText;
        public string OriginalText
        {
            get { return _originalText; }
            set 
            {
                _originalText = value;
                OnPropertyChanged("OriginalText");
            }
        }
        private string _piglatinizedText;
        public string PiglatinizedText
        {
            get { return _piglatinizedText; }
            set
            {
                _piglatinizedText = value;
                OnPropertyChanged("PiglatinizedText");
            }
        }
        public void ConvertOriginalText()  //your button calls this
        {
            //your pig latin logic here
            // set _piglatinizedText to your output
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
