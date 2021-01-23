      private readonly DelegateCommand<string> _lostFocusCommand;
      public DelegateCommand<string> LostFocusCommand
      {
         get { return _lostFocusCommand; }
      }
      private string _input;
      public string Input
      {
         get { return _input; }
         set
         {
            _input = value;
            _lostFocusCommand.RaiseCanExecuteChanged();
         }
      }
	 
