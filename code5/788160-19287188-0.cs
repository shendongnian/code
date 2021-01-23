    public ConnectViewModel(ConnectEvents connectEvents)
    {
        public event EventHandler<EventArgs> SomethingHappenedEvent;
         ...
         private void DoSomething()
         {
              if (SomethingHappenedEvent != null)
              {
                  SomethingHappenedEvent(this, newEventArgs());
              }
         }
         RelayComand _somethingCommand;
         public ICommand SomethingHappenedCommand
         {   
              get
              {
                  if (_someethingCommand == null)
                       _somethingCommand = new RelayCommand(DoSomething)
               }
         }
    }
