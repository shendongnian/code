    public IList<Image> LoadImagesFromFiles(string[] files)
    {
        // thread safe collection
        var bag = new System.Collections.Concurrent.ConcurrentBag<Image>();
        files.AsParallel().ForAll(file =>
        {
            var img = Image.FromFile(file);
            bag.Add(img);
        });
        return bag.ToList();
    }
