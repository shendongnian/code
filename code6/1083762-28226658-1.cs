     class DelegateCmdEx : DelegateCommand
    {       
        public DelegateCmdEx(Action executeMethod):base(executeMethod)
        {
        }
        public DelegateCmdEx(Action executeMethod, Func<bool> canExecuteMethod)
            : base(executeMethod, canExecuteMethod)
        {
        }
        public override event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
