    private async Task readFile()
        {
            StorageFolder local = KnownFolders.PicturesLibrary;
            if (local != null)
            {
                var dataFolder = await local.GetFolderAsync("msgGen");
                var file = await dataFolder.GetFileAsync("Msg.dat");
                var stream = (await file.OpenReadAsync()).AsStream();
                var msg = new StreamReader(stream);
                var text = msg.ReadLine();
                this.textBlock.Text = text;
                stream.Dispose();
            }
        }
    private async Task createFile()
        {
            byte[] mensaje = System.Text.Encoding.UTF8.GetBytes("Este Mensaje".ToCharArray());
            var local = KnownFolders.PicturesLibrary;
            var dataFolder = await local.CreateFolderAsync("msgGen", CreationCollisionOption.ReplaceExisting);
            var file = await dataFolder.CreateFileAsync("Msg.dat", CreationCollisionOption.OpenIfExists);
            var s = await file.OpenStreamForWriteAsync();
            s.Write(mensaje, 0, mensaje.Length);
            s.Dispose();
        }
