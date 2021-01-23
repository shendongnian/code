    public void LoadImagesFromFiles(string[] files)
    {
        Mutex imageListLock = new Mutex();
        files.AsParallel().ForAll(file =>
        {
            var img = Image.FromFile(file);
            imageListLock.WaitOne();
            this.imageList1.Images.Add(img);
            imageListLock.ReleaseMutex();
        });
    }
