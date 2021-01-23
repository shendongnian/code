    public class NullCommand : ICommand
    {
        private static readonly Lazy<NullCommand> _instance = new Lazy<NullCommand>(() => new NullCommand());
        private NullCommand()
        {
        }
        public event EventHandler CanExecuteChanged;
        public static ICommand Instance
        {
            get { return _instance.Value; }
        }
        public void Execute(object parameter)
        {
            throw new InvalidOperationException("NullCommand cannot be executed");
        }
        public bool CanExecute(object parameter)
        {
            return false;
        }
    }
