      public ICommand MyRemoveCommand {get;set;}
      this.MyRemoveCommand = new DelegateCommand(this.RemoveCommandExecute, this.CanRemoveCommandExecute);
      private bool CanRemoveCommandExecute()
      {
          return this.CanRemove;
      }
      private bool RemoveCommandExecute()
      {
          if(!this.CanRemoveCommandExecute)
            return;
         //execution logic here
      }
