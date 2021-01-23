     void HandleLoaded(object sender, RoutedEventArgs e)
     {
         var viewModel = this.DataContext as ViewModel;
         if (viewModel != null)
         {
             viewModel.DoItCommand.RaiseCanExecuteChanged();
         }
     }
