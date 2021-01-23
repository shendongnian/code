    public class SaveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly MainViewModel _context;
        public SaveCommand(MainViewModel context)
        {
            _context = context;
        }
        public void Execute(object parameter)
        {
            Console.WriteLine(string.Format("Do something with {0}", _context.Place));
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
    } 
