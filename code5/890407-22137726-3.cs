    public class MyModel : ObservableObject
    {
        private string _myPropertyText;
        private bool _showText;
        private Visibility _showTextbox;
        public string MyPropertyText
        {
            get { return _myPropertyText; }
            set
            {
                _myPropertyText = value;
                RaisePropertyChanged("MyPropertyText");
            }
        }
        public bool ShowText
        {
            get { return _showText; }
            set
            {
                _showText = value;
                RaisePropertyChanged("ShowText");
                ShowTextbox = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        public Visibility ShowTextbox
        {
            get { return _showTextbox; }
            set
            {
                _showTextbox = value;
                RaisePropertyChanged("ShowTextbox");
            }
        }
    }
