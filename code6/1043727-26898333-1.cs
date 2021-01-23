    public void LoadImagesFromFiles(string[] files)
    {
        Mutex imageListLock = new Mutex();
        files.AsParallel().ForAll(file =>
        {
            imageListLock.WaitOne();
            this.imageList1.Images.Add(Image.FromFile(file));
            imageListLock.ReleaseMutex();
        });
    }
