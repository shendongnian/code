    public class MyViewModel
    {
        private readonly RelayCommand myCommand;
        public MyViewModel()
        {
            this.myCommand = new RelayCommand(this.DoStuff, () => ...);
        }
        public ICommand MyCommand
        {
            get { return this.myCommand; }
        }
        private void DoStuff() { ... }
    }
