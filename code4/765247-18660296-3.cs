    public class MainWindowViewModel
    {
        private RelayCommand _resizeCommand;
    
        public RelayCommand ResizeCommand { get { return _resizeCommand; } }
    
        public MainWindowViewModel()
        {
            this._resizeCommand = new RelayCommand(this.Resize);
        }
    
        private void Resize()
        {
            Application.Current.MainWindow.Height = 500;
        }
    }
