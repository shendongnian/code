    public class ViewModel
    {
        public Action<string> AppendTextAction { get; set; }
        public ICommand ClickCommand { get; set; }
        public ViewModel()
        {
            ClickCommand = new DelegateCommand(OnClick);
        }
        private void OnClick()
        {
            AppendTextAction.Invoke(" test");
        }
    }
