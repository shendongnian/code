    public class ViewModel
    {
        public IRelayCommand EnterCommand { get; protected set; }
        public ViewModel()
        {
            this.EnterCommand = new RelayCommand(EnterCommandExecuted, CanExecuteEnterCommand);
            this.MyList = new ObservableCollection<string>();
        }
        private void EnterCommandExecuted(object obj)
        {
            FillData();//Pass your Data here
        }
        private bool CanExecuteEnterCommand(object obj)
        {
            return true;
        }
        private void FillData()
        {
            MyList.Clear();
            MyList.Add("1");
            MyList.Add("2");
            MyList.Add("3");
            MyList.Add("4");
        }
        public ObservableCollection<string> MyList { get; private set; }
    }
