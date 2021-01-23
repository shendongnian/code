    private static T GetObjectFromFile<T>(string filename)
        {
            IsolatedStorageFile AppIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream ISFileStream = AppIsolatedStorage.OpenFile(filename, System.IO.FileMode.Open);
            byte[] buffer = new byte[ISFileStream.Length];
            ISFileStream.Read(buffer, 0, buffer.Length);
            ISFileStream.Close();
            string data = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            if (typeof(T) == typeof(MonitorBriefs))
            {
                return (T)(object)JsonParser.ParseMonitorBrief(data);//this is incorrect statement
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
        }
