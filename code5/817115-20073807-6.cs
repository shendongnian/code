        if(IsolatedStorageSettings.ApplicationSettings.Contains("State"))
                {
               Byte [] array=  IsolatedStorageSettings.ApplicationSettings["State"] as Byte[];
     MemoryStream stream = new MemoryStream(array);
                    WriteableBitmap wb= new WriteableBitmap(200, 200);
                    wb.LoadJpeg(stream);
        //now assign wb as a source to any image control.
            IsolatedStorageSettings.ApplicationSettings.Remove("State");
                                IsolatedStorageSettings.ApplicationSettings.Save();
                }
