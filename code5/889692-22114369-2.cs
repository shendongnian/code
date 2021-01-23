    async void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
            byte[] buffer = new byte[e.Result.Length];
            await e.Result.ReadAsync(buffer, 0, buffer.Length);
            using (IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = storageFile.OpenFile("MyDownloadedFile.pdf", FileMode.Create))
                {
                    await stream.WriteAsync(buffer, 0, buffer.Length);
                }
            }
            App.RootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            Deployment.Current.Dispatcher.BeginInvoke(() =>
                    MessageBox.Show("The pdf has been downloaded!"
                                    , "PDF Download Success", MessageBoxButton.OK)
                );
    }
