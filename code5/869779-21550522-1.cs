    protected override void OnNavigatedTo(NavigationEventArgs e)
         { IsolatedStorageSettings MemorySettings = IsolatedStorageSettings.ApplicationSettings;
             if(MemorySettings.Contains("SelectedItem"))
                {
                   newpatterns newdata = MemorySettings["SelectedItem"] as newpatterns ;
                }
         }
