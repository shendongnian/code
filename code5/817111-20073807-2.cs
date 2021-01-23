    WritableBitmap wb=new WritableBitmap (i1,null);
        if(!IsolatedStorageSettings.ApplicationSettings.Contains("State"))
        {
         IsolatedStorageSettings.ApplicationSettings["State"] = wb;
                        IsolatedStorageSettings.ApplicationSettings.Save();
        }
