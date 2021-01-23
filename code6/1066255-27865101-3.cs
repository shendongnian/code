    public sealed class ThumbnailCache
    {
        public ThumbnailCache(string connectionString)
        {
            _connectionString = connectionString;
        }
        readonly string _connectionString;
        readonly Dictionary<int, Thumbnail> _cache = new Dictionary<int, Thumbnail>();
        public Thumbnail GetThumbnail(int id)
        {
            Thumbnail thumbnail;
            if (!_cache.TryGetValue(id, out thumbnail))
            {
                // Not in the cache, so load entity from database
                using (var db = new MoviesContext(_connectionString))
                {
                    thumbnail = db.Thumbnails.AsNoTracking().Find(id);
                }
                _cache.Add(id, thumbnail);
            }
            return thumbnail;
        }
    }
