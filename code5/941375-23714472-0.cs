    private void locChoice(object sender, RoutedEventArgs e)
            {
                IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
                string filePath = "locations.txt";
    
                if (store.FileExists(filePath))
                { 
                   Debug.WriteLine("Files Exists");
                    try
                    {
                        string fileData;
                        using (IsolatedStorageFileStream isoStream =
                            new IsolatedStorageFileStream("locations.txt", FileMode.Open, store))
                        {
                            using (StreamReader reader = new StreamReader(isoStream))
                            {
                                fileData = reader.ReadToEnd();
                            }
                        }
                        testLocationPicker.ItemsSource = fileData.Split(';');
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
    
                testLocationPicker.Open();
            }
