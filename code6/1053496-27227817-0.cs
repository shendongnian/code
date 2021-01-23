    private async void Application_Launching(object sender, LaunchingEventArgs e) 
            { 
                try 
                { 
                    await ApplicationData.Current.LocalFolder.GetFileAsync(DB_PATH); 
                    Connection = new SQLiteAsyncConnection(DB_PATH); 
                } 
                catch (FileNotFoundException) 
                { 
                  CreateDbAsync(); // create if not exists
                } 
            }
