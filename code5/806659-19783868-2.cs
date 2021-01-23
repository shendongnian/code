    private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            SoundData data = (sender as MenuItem).DataContext as SoundData;
            MessageBoxResult result = MessageBox.Show("Do you want to delete this item ?", "Are you sure ?", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                if (data == null)
                {
                    MessageBox.Show("The file doesn't exist");
                    return;
                }
                using (var storageFolder = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (storageFolder.FileExists(data.FilePath))
                    {
                        storageFolder.DeleteFile(data.FilePath);
                        
                        App.ViewModel.CustomSounds.Items.Remove(data);
                        // Save the list of CustomSounds to IsolatedStorage.ApplicationSettings
                        var JsonData = JsonConvert.SerializeObject(App.ViewModel.CustomSounds);
                        IsolatedStorageSettings.ApplicationSettings[SoundModel.CustomSoundKey] = JsonData;
                        IsolatedStorageSettings.ApplicationSettings.Save();
                        App.ViewModel.IsDataLoaded = false;
                        App.ViewModel.LoadData();
                        
                    }
                    else
                    {
                        MessageBox.Show("File doesn't exist");
                        return;
                    }
                }
            }
            else
            {
                return;
            }
        } 
