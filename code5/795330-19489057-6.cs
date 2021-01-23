    internal class ReadInventoryFilesCommand : ICommand
    {
      public ReadInventoryFilesCommand(ResourceViewModel viewModel)
      {
        _viewModel = viewModel;
        _viewModel.PropertyChanged+= (s,e) => { 
                                      if (e.PropertyName == "CanUpdate") RaiseCanExecuteChanged();
                                     };
      }
      public event EventHandler CanExecuteChanged;
      private ResourceViewModel _viewModel;
      public bool CanExecute(object parameter)
      {
        return _viewModel.CanUpdate;
      }
      public void Execute(object parameter)
      {
        _viewModel.ReadInventroyFiles(parameter.ToString());
      }
      void RaiseCanExecuteChanged() {
        var handler = this.CanExecuteChanged;
        if (handler != null) handler(this,EventArgs.Empty);
      }
    }
