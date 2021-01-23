    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                byte[] ProtectedPinByte = this.ReadPinFromFile();
                byte[] PinByte = ProtectedData.Unprotect(ProtectedPinByte, null);
                storedUser = Encoding.UTF8.GetString(PinByte, 0, PinByte.Length);
                NavigationService.Navigate(new Uri("/Views/Menu.xaml", UriKind.Relative));
            }
            catch
            {
                NavigationService.Navigate(new Uri("/LoginScreens/LoginSelection.xaml", UriKind.Relative));
            }
        }
