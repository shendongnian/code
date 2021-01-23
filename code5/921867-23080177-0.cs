     private async static void StoreToFileAsync(string filename, object data)
     {
         using (IsolatedStorageFile AppIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
         {
           if (IsolatedStorageFileExist(filename))
                AppIsolatedStorage.DeleteFile(filename);
           if (data != null)
           {
            string json = await Task.Factory.StartNew<string>(() => JsonConvert.SerializeObject(data));
            if (!string.IsNullOrWhiteSpace(json))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(json);
                using (Mutex mutex = new Mutex(false, filename))
                {
                 try
                 {
                  mutex.WaitOne();
                  using (IsolatedStorageFileStream ISFileStream = AppIsolatedStorage.CreateFile(filename))
                      await ISFileStream.WriteAsync(buffer, 0, buffer.Length);
                 }
                 catch {}
                 finally { mutex.ReleaseMutex(); }
            }
        }
       }
    }
