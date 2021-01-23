    private ObservableCollection<ProcessTrigger> _listProcessTriggers;
        public ObservableCollection<ProcessTrigger> ListProcessTriggers
        {
            get { return _listProcessTriggers; }
            set { _listProcessTriggers= value; RaisePropertyChanged("ListProcessTriggers"); }
        }
    public ProcessViewModel()
    {
        using(var context = new PACEContext())
        {
            this.Entity = context.Processes.FirstOrDefault(i => i.ID == 1);
            ListProcessTriggers = Entity.ProcessTriggers;
            IsInEditMode = true;
        }
    }
