    public ObservableCollection<AgentListEntryViewModel> AgentsViewModel
    {
         get { return _agentsViewModel; }
         set 
         {
              if(_agentsViewModel != value){
                _agentsViewModel = value; 
                OnPropertyChanged("AgentsViewModel"); //or however you are calling your property changed
              }
         }
    }
