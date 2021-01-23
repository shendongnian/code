    string fileContent = string.Empty;
    //Read file within IsolatedStorage
    using (IsolatedStorageFile storage = IsolatedStorageFile.GetStore((IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly | IsolatedStorageScope.User), null, null))
    {
       using (StreamReader reader = new StreamReader(storage.OpenFile("ReadMe.txt", FileMode.Open)))
        {
           fileContent = reader.ReadToEnd();
        }
    }
    //Write to a textfile
    File.WriteAllText(@"File path", fileContent);
