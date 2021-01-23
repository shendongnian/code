    public class MainViewModel
    {
        public MainViewModel()
        {
            ShowPopupCommand = new RelayCommand(o =>
            {
                var wnd = o as Window;
                var putBreakPointhere = 1;
            });
        }
        public ICommand ShowPopupCommand { get; set; }
    }
