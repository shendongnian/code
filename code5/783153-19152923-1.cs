    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            ApplyCommand = new DelegateCommand<Canvas>(canvas =>
                {
                    string userLayout = XamlWriter.Save(canvas);
                    // save userLayout for later use ...
                });
        }
        public DelegateCommand<Canvas> ApplyCommand { get; set; }
    }
