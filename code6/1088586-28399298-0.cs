     private void Refresh()
        {
            try
            {
                List<ViewerConfiguration> newlyAddedFiles = GetConfigurations();
                //should not update on other thread than on main thread
                App.Current.Dispatcher.BeginInvoke((ThreadStart)delegate()
                {
                    foreach (ViewerConfiguration config in newlyAddedFiles)
                    {
                        Configurations.Add(config);
                    }
                });
            }
            catch (Exception ex)
            {
                
            }
        }
