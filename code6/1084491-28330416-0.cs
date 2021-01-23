    private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            
            await SaveAppSettingsAsync();
            
            deferral.Complete();
        }
    private async void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null)
            {
                e.Handled = true;
                if (rootFrame.CurrentSourcePageType == typeof(MainPage))
                {
                    await SaveAppSettingsAsync();
                    this.Exit();
                }
                else if (rootFrame.CanGoBack)
                    rootFrame.GoBack();
            }
        }
