    public class MainViewModel : ViewModelBase
    {
        private readonly IDialogService _dialog;
        public MainViewModel(IDialogService dialog)
        {
            _dialog = dialog;
        }
    }
