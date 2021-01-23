    //something like this    
    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
    {
         using (var storeStream = store.OpenFile("file.bin", System.IO.FileMode.Open))
         {
              var memoStream = new System.IO.MemoryStream();
              storeStream.CopyTo(memoStream);
              return memoStream;
         }
    }
