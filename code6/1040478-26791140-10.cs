    public class SaveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly string _file;
        public SaveCommand(string file)
        {
            _file = file;
        }
        public void Execute(object parameter)
        {
            Debug.WriteLine("Save logic here, maybe...");
            Debug.WriteLine(string.Format("...and remove cache file {0}", _file));
            File.Delete(_file);
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
