    class ThumbnailManager
    {
        private Dictionary<Tuple<string, int, int>, string> _thumbnails =
            new Dictionary<Tuple<string, int, int>, string>();
        private Dictionary<Tuple<string, int, int>, Task<string>> _workers =
            new Dictionary<Tuple<string, int, int>, Task<string>>();
        private readonly object _lock = new object();
        public async Task<string> RetrieveThumbnail(string originalFile, int width, int height)
        {
            Tuple<string, int, int> key = Tuple.Create(originalFile, width, height);
            Task task;
            lock (_lock)
            {
                string fileName;
                if (_thumbnails.TryGetValue(key, out fileName))
                {
                    return fileName;
                }
                if (!_workers.TryGetValue(key, out task))
                {
                    task = Task.Run(() => ResizeFile(originalFile, width, height));
                    _workers[key] = task;
                }
            }
            string result = await task;
            lock (_lock)
            {
                _thumbnails[key] = result;
                _workers.Remove(key);
            }
            return result;
        }
    }
    string ResizeFile(string originalImageFilepath, int width, int height)
    {
        string cachedImageFilepath = GenerateCachedImageFilepath(originalImageFilepath);
        if (!FileExists(cachedImageFilepath))
        {
            byte[] resizedImage = _imageResizer.ResizeImage(originalImageFilepath, width, height);
            _physicalFileManager.WriteToFile(cachedImageFilepath, resizedImage);
        }
        return cachedImageFilepath;
    }
