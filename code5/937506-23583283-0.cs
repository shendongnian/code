    public static async Task<T> ReadJsonEx<T>(String fileName)
    {
        if (String.IsNullOrEmpty(fileName)) return default(T);
        string mutexName = "dependantOnApp" + fileName;
        return await Task.Run<T>(() =>
        {
            using (Mutex myMutex = new Mutex(false, mutexName))
            {
                try
                {
                    myMutex.WaitOne();
                    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                    using (var stream = new IsolatedStorageFileStream(fileName, FileMode.Open, store))
                    using (var sr = new StreamReader(stream))
                    using (var jr = new JsonTextReader(sr))
                        return (T)jsonSerializer.Deserialize(jr);
                }
                catch { throw new Exception("Exception"); }
                finally { myMutex.ReleaseMutex(); }
            }
        });
    }
