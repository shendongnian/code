    private async void lockHelper(Uri backgroundImageUri, string backgroundAction)
            {
                try
                {
                    //If you're not the provider, this call will prompt the user for permission. 
                    //Calling RequestAccessAsync from a background agent is not allowed. 
                    var op = await LockScreenManager.RequestAccessAsync();
                    //Check the status to make sure we were given permission. 
                    bool isProvider = LockScreenManager.IsProvidedByCurrentApplication; if (isProvider)
                    {
                        //Do the update. 
                        Windows.Phone.System.UserProfile.LockScreen.SetImageUri(backgroundImageUri);
                        System.Diagnostics.Debug.WriteLine("New current image set to {0}", backgroundImageUri.ToString());
                    }
                    else { MessageBox.Show("You said no, so I can't update your background."); }
                }
                catch (System.Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); }
            }
