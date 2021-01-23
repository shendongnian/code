    var store =     
        System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication();
    var newPath = "MyFileName.png";
    
    if (store.FileExists(newPath)) store.DeleteFile(newPath);
    var stream = store.CreateFile(newPath);
    BitmapImage i = new BitmapImage();
    i.SetSource(photoResult.ChosenPhoto);
    WriteableBitmap imageToSave = new WriteableBitmap(i);
    imageToSave.SaveJpeg(stream, 173, 173, 0, 100);
    stream.Flush();
    stream.Close();
