Creating a Folder and File under IsolatedStorage
    using (IsolatedStorageFile storage = IsolatedStorageFile.GetStore((IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly | IsolatedStorageScope.User), null, null))
    {
        storage.CreateDirectory(@"SampleStorageFolder");
        storage.CreateFile(@"SampleStorageFolder\ReadMe.txt");
    }
Reading File created under IsolatedStorage
    using (IsolatedStorageFile storage = IsolatedStorageFile.GetStore((IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly | IsolatedStorageScope.User), null, null))
    {
       using (StreamReader reader = new StreamReader(storage.OpenFile("ReadMe.txt", FileMode.Open)))
        {
           string content = reader.ReadToEnd();
        }
    }
