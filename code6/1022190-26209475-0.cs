    public Page()
    {
      var mainViewModel = this.DataContext as MainViewModel;
      if(mainViewModel != null)
      {
        mainViewModel.PasswordBox = userPassword;
      }
    }
