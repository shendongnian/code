    public class MainWindowViewModel 
    {
        ICommand WindowClosingCommand => new RelayCommand(arg => this.WindowClosing());
        private void WindowClosing()
        {
          // do what you want.
        }
    }
