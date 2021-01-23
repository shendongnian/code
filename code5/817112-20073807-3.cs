     if(IsolatedStorageSettings.ApplicationSettings.Contains("State"))
            {
           WritableBitmap wb=  IsolatedStorageSettings.ApplicationSettings["State"] as WritableBitmap;
    //now assign wb as a source to any image control.
        IsolatedStorageSettings.ApplicationSettings.Remove("State");
                            IsolatedStorageSettings.ApplicationSettings.Save();
            }
