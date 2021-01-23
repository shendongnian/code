    public class TableNameVM : ViewModelBase
    {
        private readonly ICommand myCommand;
        public ObservableCollection<RowVM> Rows { get; set; }
        public TableNameVM()
        {
            this.myCommand = new DelegateCommand<RowVM>(ExecuteMyCommand);
            //create 10 rows
            for(int n = 1; n < 10; n++)
                this.Rows.Add(new RowVM(this.myCommand));
        }
        private void ExecuteMyCommand(RowVM row)
        {
            //do whatever
        }
    }
    public class RowVM : ViewModelBase
    {
        public ICommand MyCommand { get; private set; }
        public RowVM(ICommand myCommand)
        {
            this.MyCommand = myCommand;
        }
    }
