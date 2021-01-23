    using Windows.UI.Xaml;
    
    if (DisplayToggleBtn.IsChecked.HasValue && DisplayToggleBtn.IsChecked.Value) {
        AutumnImage.Visibility  =  Visibility.Visible
    else {
        AutumnImage.Visibility  =  Visibility.Collapsed
    }
