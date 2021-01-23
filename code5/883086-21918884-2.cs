    public BitmapImage PosterLocal
    {
       get
       {
           BitmapImage temp = new BitmapImage();
           using (IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication())
           using (IsolatedStorageFileStream file = ISF.OpenFile(posterLocal, FileMode.Open, FileAccess.Read))
                temp.SetSource(file);
           return temp;
        }
    }
    
    private string posterLocal; // this in case you probably will need to save somewhere the file name
