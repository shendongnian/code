    private bool updateInProgress;
    private ICommand update;
    public ICommand Update
    {
      get
      {
        if (update == null)
        {
          update = new RelayCommand(
              async () =>
              {
                updateInProgress = true;
                Update.RaiseCanExecuteChanged();
                await Task.Run(() => StartUpdate());
                updateInProgress = false;
                Update.RaiseCanExecuteChanged();
              },
              () => !updateInProgress);
        }
        return update;
      }
    }
