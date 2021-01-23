      protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
      {
            if (App.ViewModel != null)
                App.ViewModel.NotifyPropertyChanged("Name of property");
      }
