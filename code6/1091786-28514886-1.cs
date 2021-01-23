    public sealed class ExampleViewModel : BaseViewModel
    {
        private string _text;
    
        public ExampleViewModel()
        {
           TextCommand = new RelayCommand(TextExecute, CanTextExecute);
        }
    
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }
            
        public ICommand TextCommand { get; private set; }
    
        private void TextExecute()
        {
            // Do something with _text value...
        }
    
        private bool CanTextExecute()
        {
            return true;
        }
    }
