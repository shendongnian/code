    [ImmutableObject(true)]
    public class MyImmutableCommand : ICommand
    {
        private static bool True() { return true; }
        
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        private readonly Func<bool> _isVisible;
        [Obsolete("Will not be invoked, because the implementation never changes.")]
        public event EventHandler CanExecuteChanged;
        public MyImmutableCommand(Action execute, Func<bool> canExecute = null, Func<bool> isVisible = null)
        {
            _execute = execute;
            _canExecute = canExecute ?? True;
            _isVisible = isVisible ?? True;
        }
        public bool CanExecute()
        {
            return _canExecute(); 
        }
        public bool IsVisible()
        {
            return _isVisible(); 
        }
        public void Execute()
        {
            _execute();
        }
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }
        void ICommand.Execute(object parameter)
        {
            Execute();
        }
    }
