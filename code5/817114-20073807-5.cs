        WritableBitmap wb=new WritableBitmap (i1,null);
    Byte [] array=ConvertToBytes(wb)
            if(!IsolatedStorageSettings.ApplicationSettings.Contains("State"))
            {
             IsolatedStorageSettings.ApplicationSettings["State"] = array;
                            IsolatedStorageSettings.ApplicationSettings.Save();
            }
