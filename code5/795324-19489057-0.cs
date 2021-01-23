    event EventHandler ICommand.CanExecuteChanged;
    bool ICommand.CanExecute(object parameter)
    {
        return _viewModel.CanUpdate;
    }
    void ICommand.Execute(object parameter)
    {
        _viewModel.ReadInventroyFiles(parameter.ToString());
    }
    void RaiseCanExecuteChanged() {
      var handler = this.CanExecuteChanged;
      if (handler != null) handler(this,EventArgs.Empty);
    }
