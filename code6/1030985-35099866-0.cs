     [DebuggerStepThrough]
            public Boolean CanExecute(Object parameter)
            {
    
                var valu = _canExecute == null ? true : _canExecute();
                CommandManager.InvalidateRequerySuggested();
                return valu;
            }
