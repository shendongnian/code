    async void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        byte[] buffer = new byte[e.Result.Length];
        await e.Result.ReadAsync(buffer, 0, buffer.Length);
        using (IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (IsolatedStorageFileStream stream = storageFile.OpenFile("your-file.pdf", FileMode.Create))
            {
                await stream.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }
