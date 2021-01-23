    public class MainViewModel
    {
        public DelegateCommand MyCommand { get; set; }
        private bool canExecute = true;
        public MainViewModel()
        {
            MyCommand = new DelegateCommand(SayHi, () => canExecute);
        }
        public void SayHi()
        {
            MessageBox.Show("Hi");
            canExecute = false;
        }
    }
