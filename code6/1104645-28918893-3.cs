    class MyViewModel:INotifyPropertyChanged
    {
        private TicketManager mgr;
        public ObservableCollection<Ticket> List { get; set; }
        private string text;
        private string state;
        private int ticketNumber;
        private readonly DelegateCommand<object> MyButtonCommand;
        public Class1()
        {
            mgr = new TicketManager();
            List = mgr.GetTickets();
            MyButtonCommand = new DelegateCommand<object>((s) => { AddListToGrid(text, state, ticketNumber); }, (s) => { return !string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(state); });
        }
        private void AddListToGrid(string text, string state, int ticketNumber)
        {
            List.Add(new Ticket() {Text=text,State=state,TicketNumber=ticketNumber });
        }
        public DelegateCommand<object> MainCommand
        {
            get
            {
                return MyButtonCommand;
            }
        }
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
                MyButtonCommand.RaiseCanExecuteChanged();
            }
        }
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged("State");
                MyButtonCommand.RaiseCanExecuteChanged();
            }
        }
        public int TicketNumber
        {
            get
            {
                return ticketNumber;
            }
            set
            {
                ticketNumber = value;
                OnPropertyChanged("TicketNumber");
                MyButtonCommand.RaiseCanExecuteChanged();
            }
        }
        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
