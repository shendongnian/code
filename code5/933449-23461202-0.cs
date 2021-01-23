    public class MainViewModel : ViewModelBase
    {
        public RelayCommand<EventArgs> ParseCommand { get; set; }
        public MainViewModel()
        {
            this.ParseCommand = new RelayCommand<EventArgs>(ParseLineExecute, CanParseLine);
        }
        public bool CanParseLine(EventArgs e)
        {
            var pressedKey = (e != null) ? (KeyEventArgs)e : null;
            if (pressedKey.Key == Key.Space && pressedKey != null)
            {
                return true;
            }
            else
            {
                return false;
            }       
        }
        public void ParseLineExecute(EventArgs e)
        {
            //parsing code
        }
    }
