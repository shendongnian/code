    public class EnterKeyCommand : ICommand
    {
        private bool canExecute;
        public EnterKeyCommand()
        {
            this.canExecute = true;
        }
        public bool CanExecute(object parameter)
        {
            return this.canExecute;
        }
        public void Execute(object parameter)
        {
            this.canExecute = false;
            Debug.WriteLine("Running Command");
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            timer.Tick += (sender, args) =>
                {
                    this.canExecute = true;
                    timer.Stop();
                };
            timer.Start();
        }
        public event EventHandler CanExecuteChanged;
    }
