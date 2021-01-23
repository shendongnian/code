    [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            bool result = true;
            if (_canExecute != null)
            {
                result = _canExecute();
                CommandManager.InvalidateRequerySuggested();
            }
            return result;
        }
