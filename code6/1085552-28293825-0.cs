    class MyCommand: ICommand
    {
      public bool CanExecute(object parameter)
      {
        return true; // if your command is "enabled" otherwhise return false
      }
    
      public void Execute(object parameter)
      {
        // do something usefull
      }
    }
