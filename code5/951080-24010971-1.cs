    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // Assumes your DataContext is correctly set to an instance of YourViewModel
        YourViewModel viewModel = (YourViewModel)DataContext; 
        viewModel.DelegateProperty += CanBeCalledAnythingButMustMatchTheDelegateSignature;
    }
