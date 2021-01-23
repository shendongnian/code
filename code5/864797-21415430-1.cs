    public sealed class AsyncDelegateCommand : ICommand
    {
        readonly Func<object, Task> onExecute;
        readonly Predicate<object> onCanExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public AsyncDelegateCommand(Func<object, Task> onExecute)
            : this(onExecute, null) { }
        public AsyncDelegateCommand(Func<object, Task> onExecute, Predicate<object> onCanExecute)
        {
            if (onExecute == null)
                throw new ArgumentNullException("onExecute");
            this.onExecute = onExecute;
            this.onCanExecute = onCanExecute;
        }
        #region ICommand Methods
        
        public async void Execute(object parameter)
        {
            await onExecute(parameter);
        }
        public bool CanExecute(object parameter)
        {
            return onCanExecute != null ? onCanExecute(parameter) : true;
        }
        #endregion
    }
