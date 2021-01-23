    private void CopyToIsolatedStorage(string file, IsolatedStorageFile store, bool overwrite = true)
    {
                if (store.FileExists(file) && !overwrite)
                    return;
     
                using (var resourceStream = Application.GetResourceStream(new Uri(file, UriKind.Relative)).Stream)
                using (var fileStream = store.OpenFile(file, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    int bytesRead;
                    var buffer = new byte[resourceStream.Length];
                    while ((bytesRead = resourceStream.Read(buffer, 0, buffer.Length)) > 0)
                        fileStream.Write(buffer, 0, bytesRead);
                }
    }
