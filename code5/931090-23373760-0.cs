    IsolatedStorageFile savegameStorage = IsolatedStorageFile.GetUserStoreForApplication();
    IsolatedStorageFileStream fs = null;
    using (fs = savegameStorage.CreateFile("FILENAME"))
    {
    	if (fs != null)
    	{
            var index = 0;
    		foreach(var rigaStor in rigaStorico.Reverse())
    		{
    			byte[] bytes = System.BitConverter.GetBytes(rigaStor.Name);
    			fs.Write(bytes, index, bytes.Length);
                index = bytes.Length;
    		}
    	}
    }
