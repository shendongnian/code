    public BitmapImage FirstImage // getter - BitmapImage
    {
        get
        {
           if (String.IsNullOrEmpty(ImagePath[0])) return null;
           BitmapImage temp = new BitmapImage();
           using (IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication())
           using (IsolatedStorageFileStream file = ISF.OpenFile(ImagePath[0], FileMode.Open, FileAccess.Read))
                temp.SetSource(file);
           return temp;
        }
    }
