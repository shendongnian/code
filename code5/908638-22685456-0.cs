    public class WorkClass : INotifyPropertyChanged
    {
        public WorkClass()
        {
            test = new testCommand2(this);
        }
        // Will be called on command execturion
        public Test2Action()
        {
        }
    public event PropertyChangedEventHandler PropertyChanged;
    private Book mybook;
    private ObservableCollection<Book> bookList;
    public Book Mybook
    {
        get { return mybook; }
        set
        {
            book = value;
            OnPropertyChanged("Mybook");
        }
    }
    public ObservableCollection<Book> BookList
    {
        get { return bookList; }
        private set
        {
            bookList = value;
            OnPropertyChanged("BookList");
        }
    }
    testCommand2 test;
    public ICommand Test { get { return test; } }
    private class testCommand2 : ICommand
    {
        private readonly WorkClass _wc;
        public testCommand2(WorkClass wc)
        {
           _wc = wc;
        }
        public void Execute(object parameter)
        {
            _wc.Test2Action();
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
    protected void OnPropertyChanged(string name)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
